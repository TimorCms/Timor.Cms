using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Timor.Cms.Infrastructure.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException(string error, string errorDetail = null)
        {
            ErrorMessage = error;

            ErrorDetail = errorDetail;
        }

        public BusinessException(string error, Dictionary<string, string> trace)
        {
            ErrorMessage = error;

            ErrorDetail = JsonSerializer.Serialize(trace);
        }

        public BusinessException(string error, string traceKey, string traceValue)
        {
            ErrorMessage = error;

            ErrorDetail = JsonSerializer.Serialize(new Dictionary<string, string> {{traceKey, traceValue}});
        }

        protected BusinessException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ErrorMessage = serializationInfo.GetString($"{nameof(BusinessException)}.{nameof(ErrorMessage)}");

            ErrorDetail = serializationInfo.GetString($"{nameof(BusinessException)}.{nameof(ErrorDetail)}");
        }

        public string ErrorMessage { get; set; }

        public string ErrorDetail { get; set; }
    }
}