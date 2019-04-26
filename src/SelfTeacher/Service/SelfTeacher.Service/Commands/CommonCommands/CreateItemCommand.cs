using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Helpers.DataContext;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using System;

namespace SelfTeacher.Service.Commands.CommonCommands
{
    /// <summary>
    /// Command for adding entity type object to DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Tdto"></typeparam>
    public class CreateItemCommand<T, Tdto> : Command<Guid>
        where T: Entity
        where Tdto: EntityDto
    {
        #region Private fields
        private readonly Tdto _item;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        #endregion

        #region ctor

        public CreateItemCommand(
            Tdto item,
            DataContext context,
            IMapper mapper,
            ILogger logger)
            :base(logger)
        {
            this._item = item;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Public methods

        protected override Guid Run()
        {

            _logger.LogTrace($"Start command Create item command for type {typeof(T).ToString()}");
            var T = _mapper.Map<T>(_item);
            T.Id = Guid.NewGuid();
            _logger.LogTrace($"Create new ID for entity with type {typeof(T).ToString()} equal {T.Id}");

            _context.Add<T>(T);

            _context.SaveChanges();
            _logger.LogTrace($"Finish command for create for type {typeof(T).ToString()} and id {T.Id}");

            return T.Id;
        }

        #endregion
    }
}
