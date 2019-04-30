using ServiceTeacher.Service.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceTeacher.Service.Domain.Entities
{
    /// <summary>
    /// Base class of entities in system
    /// </summary>
    public class Entity
    {
        [Key]
        /// <summary>
        /// Idetificator of entity
        /// </summary>
        public Guid Id { get; set; }

        public EItemState State { get; set; }
    }
}
