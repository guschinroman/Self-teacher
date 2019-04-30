using System;

namespace ServiceTeacher.Service.Infrastructure.Exceptions
{
    public class OperationCannotBePerformedException: Exception
    {
        public OperationCannotBePerformedException(string message)
            :base(message)
        {

        }
    }
}
