using System.Collections.Generic;

namespace ServiceTeacher.Service.Domain.Dtos
{
    public interface IListDto<T>
    {
        IList<T> Result { get; set; }
    }
}
