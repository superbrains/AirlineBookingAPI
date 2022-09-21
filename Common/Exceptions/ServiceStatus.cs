using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceStatusAttribute : Attribute
    {
        public int StatusCode { get; }
        public string Message { get; }
        public string UserMessage { get; }

        public ServiceStatusAttribute(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            UserMessage = message;
        }
    }
}
