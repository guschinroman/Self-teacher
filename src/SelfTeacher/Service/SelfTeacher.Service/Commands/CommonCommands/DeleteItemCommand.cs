using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Helpers.DataAccess;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Entities.Enum;
using ServiceTeacher.Service.Infrastructure.Exceptions;
using System;

namespace SelfTeacher.Service.Commands.CommonCommands
{
    public class DeleteItemCommand<T, TDto> : Command
        where T : Entity
    {
        #region Private fields

        private readonly Guid _Id;
        private readonly DataContext _dataContext;
        #endregion

        #region ctor

        public DeleteItemCommand(
            Guid Id,
            DataContext dataContext,
            ILogger logger)
            : base(logger)
        {
            _Id = Id;
            _dataContext = dataContext;
        }

        #endregion

        #region Public methods

        protected override void Run()
        {
            Logger.LogTrace($"Start command delete item by id with id {_Id}");

            var item = _dataContext.Find<T>(_Id);

            if (item.State == EItemState.Deleted)
            {
                throw new AppException("Object was deleted");
            }

            item.State = EItemState.Deleted;


            _dataContext.Update<T>(item);

            _dataContext.SaveChanges();

            Logger.LogTrace($"Finish command delete item by id with id {_Id} with ok responce");
            
        }

        #endregion
    }
}
