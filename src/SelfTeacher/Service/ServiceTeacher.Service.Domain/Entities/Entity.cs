using ServiceTeacher.Service.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceTeacher.Service.Domain.Entities
{
    /// <summary>
    /// Base class of entities in system
    /// </summary>
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Idetificator of entity
        /// </summary>
        public Guid Id { get; set; }

        public EItemState State { get; set; }
    }
}
