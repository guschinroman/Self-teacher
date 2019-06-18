using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Helpers.DataAccess;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services.Translators;
using System;

namespace SelfTeacher.Service.Commands.CommonCommands
{
    /// <summary>
    /// Command for update database dto
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="Tdto">Dto entity type</typeparam>
    public class UpdateItemCommand<T, Tdto>: Command
         where T : Entity
        where Tdto : EntityDto
    {
        #region Private fields

        private readonly Tdto _item;
        private readonly Guid _Id;
        private readonly ITranslator<Tdto, T> _translator;
        private readonly DataContext _context;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public UpdateItemCommand(
            Tdto item,
            Guid Id,
            ITranslator<Tdto, T> translator,
            DataContext context,
            ILogger logger)
            : base(logger)
        {
            _item = item;
            _Id = Id;
            _translator = translator;
            _context = context;
            _logger = logger;
        }

        #endregion

        #region Public methods

        protected override void Run()
        {
            _logger.LogTrace($"Start command Update item command for type {typeof(T).ToString()} and id {_Id}");
            var T = _translator.Translate(_item);
            
            _context.Update(T);

            _context.SaveChanges();
            _logger.LogTrace($"Finish command for update for type {typeof(T).ToString()} and id {_Id}");
        }

        #endregion
    }
}
