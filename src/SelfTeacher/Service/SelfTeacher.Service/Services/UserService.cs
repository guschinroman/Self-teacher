using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SelfTeacher.Service.Helpers.DataAccess;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Entities.Enum;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Exceptions;
using ServiceTeacher.Service.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ServiceTeacher.Service.Infrastructure.Services
{
    /// <summary>
    /// Implementation of user service
    /// </summary>
    public class UserService : IUserService
    {
        #region Private fields

        private readonly DataContext _context;
        private readonly AppSettings _appSettings;

        #endregion

        #region ctor
        public UserService(DataContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region  Public methods
        /// <summary>
        /// Method for authenricate user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public object Authenticate(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            
            if(user == null)
            {
                return null;
            }

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            var authDto = new AuthenticateDto
            {
                UserId = user.Id,
                AccessTokenLiveTime = new TimeSpan(7,0,0,0),
                Token = tokenHandler.WriteToken(token)
            };

            return authDto;

        }

        /// <summary>
        /// Registration of users
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");
            if (_context.Users.Any(t => t.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserAccountState = EUserAccountState.NotConfirmed;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Registration of vk users
        /// </summary>
        /// <param name="user"></param>
        public Guid CreateVkUser(User user)
        {
            if (_context.Users.Any(t => t.Vk_id == user.Vk_id))
            {
                var dbUser = _context.Users.FirstOrDefault(t => t.Vk_id == user.Vk_id);
                if (dbUser.UserAccountState == EUserAccountState.Banned || dbUser.UserAccountState == EUserAccountState.Deleted)
                {
                    throw new AppException("Username \"" + user.Username + "\" is banned or deleted");
                }
                return dbUser.Id;
            }

            user.PasswordHash = new byte[0];
            user.PasswordSalt = new byte[0];
            user.UserAccountState = EUserAccountState.NotConfirmed;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        /// <summary>
        /// Method for getting all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        /// <summary>
        /// Confirmation user method
        /// </summary>
        /// <param name="userId">Identificator of user</param>
        /// <param name="code">Confirmation code</param>
        public void ConfirmUser(Guid userId, string code)
        {
            var user = _context.Users.Find(userId);

            if(user == null)
            {
                throw new AppException("User not found");
            }

            if(user.ConfirmCode != code)
            {
                throw new AppException("Confirmation code is incorrect");
            }

            user.UserAccountState = EUserAccountState.Confirmed;

            _context.Users.Update(user);
            _context.SaveChanges();

        }
        

        /// <summary>
        /// Method for taking one user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        /// <summary>
        /// Edit information for user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.Firstname = userParam.Firstname;
            user.Lastname = userParam.Lastname;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Generation of password hash for user
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(password == null)
            {
                throw new ArgumentNullException("Password");
            }
            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Check password to equal hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
        }
        #endregion
    }
}
