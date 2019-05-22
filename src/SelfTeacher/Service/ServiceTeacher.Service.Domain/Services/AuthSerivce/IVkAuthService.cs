using ServiceTeacher.Service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Domain.Services.AuthSerivce
{
    public interface IVkAuthService
    {
        User GetAndSaveUser(string code);
    }
}
