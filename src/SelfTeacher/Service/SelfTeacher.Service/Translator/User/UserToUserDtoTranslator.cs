using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Infrastructure.Services.Translator;
using System;

namespace SelfTeacher.Service.Translator.User
{
    public class UserToUserDtoTranslator : Translator<ServiceTeacher.Service.Domain.Entities.User, UserDto>
    {
        protected override UserDto Map(ServiceTeacher.Service.Domain.Entities.User source)
        {
            var userDto = new UserDto
            {
                ConfirmCode = source.ConfirmCode,
                Email = source.Email,
                FirstName = source.Firstname,
                Id = source.Id,
                LastName = source.Lastname,
                Password = string.Empty,
                Username = source.Username,
                UserAccountState = source.UserAccountState
            };

            return userDto;
        }

        protected override void Map(ServiceTeacher.Service.Domain.Entities.User source, UserDto destination)
        {
            destination.ConfirmCode = source.ConfirmCode;
            destination.Email = source.Email;
            destination.FirstName = source.Firstname;
            destination.Id = source.Id;
            destination.LastName = source.Lastname;
            destination.Password = string.Empty;
            destination.Username = source.Username;
            destination.UserAccountState = source.UserAccountState;
        }
    }
}
