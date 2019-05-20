using ServiceTeacher.Service.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ServiceTeacher.Service.Domain.Services
{
    /// <summary>
    /// Interface for work with users
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method for authenricate user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        object Authenticate(string username, string password);

        /// <summary>
        /// Method for getting all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Confirmation user method
        /// </summary>
        /// <param name="userId">Identificator of user</param>
        /// <param name="code">Confirmation code</param>
        void ConfirmUser(Guid userId, string code);

        /// <summary>
        /// Method for taking one user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(Guid id);

        /// <summary>
        /// Registration of users
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        void Create(User user, string password);

        /// <summary>
        /// Edit information for user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        void Update(User user, string password = null);
    }
}
