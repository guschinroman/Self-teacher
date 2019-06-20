using ServiceTeacher.Service.Domain.Entities.Enum;
using System;

namespace SelfTeacher.Service.Infrastructure.Dtos

{
    public class AuthenticateDto
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }

        public TimeSpan AccessTokenLiveTime { get; set; }

        public EUserAccountState State { get; set; }
    }
}
