using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.AccountCommands
{
    public class GetAddClientByVkCommand : AsyncCommand
    {
        #region private fields
        #endregion

        #region ctor
        public GetAddClientByVkCommand(
            ILogger logger)
            : base(logger)
        {

        }
        #endregion

        #region public methods
        protected override Task Run()
        {

        }

        #endregion
    }
}
