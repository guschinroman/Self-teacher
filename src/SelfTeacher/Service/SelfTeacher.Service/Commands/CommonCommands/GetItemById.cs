using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Helpers.DataAccess;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Entities.Enum;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Infrastructure.Exceptions;
using System;

namespace SelfTeacher.Service.Commands.CommonCommands
{
    /// <summary>
    /// Command to getting item by identificatior
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public class GetItemById<T, TDto> : Command<TDto>
        where T: Entity
        where TDto: EntityDto
    {
        #region Private fields

        private readonly Guid _Id;
        private readonly DataContext _dataContext;
        private readonly ITranslator<T, TDto> _translator;

        #endregion

        #region ctor

        public GetItemById(
            Guid Id,
            DataContext dataContext,
            ITranslator<T, TDto> translator,
            ILogger logger)
            :base(logger)
        {
            _Id = Id;
            _dataContext = dataContext;
            _translator = translator;
        }

        #endregion

        #region Public methods

        protected override TDto Run()
        {
            Logger.LogTrace($"Start command get item by id with id {_Id}");

            var item = _dataContext.Find<T>(_Id);

            if (item.State == EItemState.Deleted)
            {
                throw new AppException("Object was deleted");
            }

            var dto = _translator.Translate(item);

            Logger.LogTrace($"Finish command get item by id with id {_Id} with ok responce");

            return dto;
        }

        #endregion
    }
}
