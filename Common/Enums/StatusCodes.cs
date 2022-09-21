using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum StatusCode
    {
        [ServiceStatus(0, "Successful")] Ok = 0,

        [ServiceStatus(1, "One or more validation failures have occurred.")]
        ValidationError = 1,
        [ServiceStatus(3, "Bad request.")] BadReqeust = 3,

        [ServiceStatus(4, "Authorization error.")]
        AuthorizationError = 4,
        [ServiceStatus(2, "Not found")] NotFound = 2,
        [ServiceStatus(10, "Pending")] Pending = 10,

        [ServiceStatus(500, "Internal server error.")]
        InternalServerError
    }

}