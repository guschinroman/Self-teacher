using Microsoft.Extensions.Logging;
using RazorLight;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.EmailSevice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTeacher.Service.Infrastructure.Services.EmailService
{
    public class ClientEmailSender : IClientEmailSender
    {
        #region private fields
        private readonly ILogger<ClientEmailSender> _logger;
        private readonly IEmailTemplateNameService _emailTemplateNameService;
        private readonly IEmailService _emailService;
        private readonly IAppSettings _appSettings;
        #endregion

        #region ctor
        public ClientEmailSender(
            IEmailTemplateNameService emailTemplateNameService,
            IAppSettings appSettings,
            IEmailService emailService,
            ILogger<ClientEmailSender> logger
            )
        {
            _emailTemplateNameService = emailTemplateNameService;
            _appSettings = appSettings;
            _emailService = emailService;
            _logger = logger;
        }
        
        #endregion

        #region public methods
        public async Task SendConfirmRegistrationEmail(string email, string name, string code)
        {
            var template = _emailTemplateNameService.GetConfirmRegistrationTemplateName();
            RazorLightEngine renderer = new RazorLightEngineBuilder()
              .UseFilesystemProject(_appSettings.EmailAccountSender.RootPathOfTemplates)
              .Build();

            var body = await renderer.CompileRenderAsync(
                _emailTemplateNameService.GetConfirmRegistrationTemplateName(),
                new RegistrationConfirmModel {
                    Username = name,
                    Link = string.Format(_appSettings.EmailAccountSender.RegistrationLinkTemplate, code)
                }
            );

            await _emailService.SendEmailAsync(email, name, body);
        }
        #endregion
    }
}
