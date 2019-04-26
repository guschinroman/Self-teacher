using System;

namespace ServiceTeacher.Service.Domain.Entities
{
    /// <summary>
    /// Base class of entities in system
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Idetificator of entity
        /// </summary>
        public Guid Id { get; set; }
    }
}
