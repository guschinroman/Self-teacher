using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Controllers
{
    public enum ECommandResults
    {
        Success,
        ServerFailedWithException,
        ObjectNotFound,
        OperationCanNotBePerformed
    }
}
