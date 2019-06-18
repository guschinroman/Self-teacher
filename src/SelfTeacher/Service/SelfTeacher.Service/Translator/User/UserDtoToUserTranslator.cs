using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Infrastructure.Services.Translator;
using System;

namespace SelfTeacher.Service.Translator.User
{
    public class UserDtoToUserTranslator : Translator<UserDto, ServiceTeacher.Service.Domain.Entities.User>
    {
        protected override ServiceTeacher.Service.Domain.Entities.User Map(UserDto source)
        {
            var user = new ServiceTeacher.Service.Domain.Entities.User
            {
                ConfirmCode = source.ConfirmCode,
                Email = source.Email,
                Firstname = source.FirstName,
                Id = source.Id ?? Guid.Empty,
                Lastname = source.LastName,
                Username = source.Username
            };

            return user;
        }

        protected override void Map(UserDto source, ServiceTeacher.Service.Domain.Entities.User destination)
        {
            destination.ConfirmCode = source.ConfirmCode;
            destination.Email = source.Email;
            destination.Firstname = source.FirstName;
            destination.Id = source.Id.HasValue ? source.Id.Value : Guid.Empty;
            destination.Lastname = source.LastName;
            destination.Username = source.Username;
        }
    }
}
