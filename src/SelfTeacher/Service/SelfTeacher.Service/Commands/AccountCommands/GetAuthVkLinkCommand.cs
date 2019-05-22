using Microsoft.Extensions.Logging;
using ServiceTeacher.Service.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.AccountCommands
{
    public class GetAuthVkLinkCommand : Command<string>
    {
        private readonly IAppSettings _settings;
        #region private fields
        #endregion

        #region ctor
        public GetAuthVkLinkCommand(
            IAppSettings settings,
            ILogger logger
            ): base(logger)
        {
            _settings = settings;
        }
        #endregion

        #region public methods
        protected override string Run()
        {
            return $"{_settings.VkAuth.AuthAdress}/?client_id={_settings.VkAuth.VkAppId}&redirect_uri={_settings.VkAuth.RedirectUrl}&response_type=code";
        }
        #endregion
    }
}
