using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.EmailService;

namespace ServiceTeacher.Service.Infrastructure.Services.EmailService
{
    public class EmailTemplateNameService : IEmailTemplateNameService
    {
        #region private fields
        #endregion

        #region ctor
        public EmailTemplateNameService()
        {

        }
        #endregion

        #region public methods
        public string GetConfirmRegistrationTemplateName()
        {
            return "Templates.ConfirmRegistrationTemplate.cshtml";
        }
        
        #endregion
    }
}
