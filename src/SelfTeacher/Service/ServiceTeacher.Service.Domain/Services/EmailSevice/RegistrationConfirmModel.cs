using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Domain.Services.EmailSevice
{
    public class RegistrationConfirmModel
    {
        public string Username { get; set; }

        public string Link { get; set; }
    }
}
