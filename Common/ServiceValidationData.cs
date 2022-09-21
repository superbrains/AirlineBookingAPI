using Common.Enums;
using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ServiceValidationData : ServiceResponseData
    {
        public ServiceValidationData(IDictionary<string, string[]> validationErrors)
            : base(StatusCode.ValidationError.GetStatusCode(),
                StatusCode.ValidationError.GetStatusMessage(), StatusCode.ValidationError.GetStatusUserMessage())
        {
            ValidationMessages = validationErrors.SelectMany(x => x.Value);
        }

        public IEnumerable<string> ValidationMessages { get; }
    }

    public class ServiceResponseData<T> : ServiceResponseData
    {
        public T Result { get; }

        public ServiceResponseData(T data)
        {
            Result = data;
        }
    }

    public class ServiceResponseData
    {
        public int Response { get; }

        protected ServiceResponseData()
            : this(StatusCode.Ok.GetStatusCode(), "Successful", "Successful")
        {
        }

        public string Message { get; }
        public string UserMessage { get; }

        public static ServiceResponseData Success()
        {
            return new ServiceResponseData();
        }

        public ServiceResponseData(int responseCode, string message, string userMessage)
        {
            Response = responseCode;
            Message = message;
            UserMessage = userMessage;
        }

        public ServiceResponseData(StatusCode statusCode, string message, string userMessage)
            : this(statusCode.GetStatusCode(), message, userMessage)
        {
        }
    }
}
