using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        // Status(Success, Failed enum) , ResultMessage,ErrorCode,Data(GenericType)

        public enum Status
        {
            Success = 200,
            Failed = 400
        };
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }
        public T Data { get; set; }

        public ApiResponse(string resultMessage, string errorCode, T data)
        {
            ResultMessage = resultMessage;
            ErrorCode = errorCode;
            Data = data;
        }

    }
}
