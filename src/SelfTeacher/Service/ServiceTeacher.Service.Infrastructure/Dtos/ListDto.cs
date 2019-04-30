using ServiceTeacher.Service.Domain.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using System.Collections.Generic;

namespace ServiceTeacher.Service.Infrastructure.Dtos
{
    public class ListDto<T> : AbstractListDto, IListDto<T>
        where T : Entity
    {
        #region ctor

        public ListDto()
        {
            Result = new List<T>();
        }

        #endregion

        #region Public properties

        public IList<T> Result { get; set; }

        #endregion
    }
}
