using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Errors
{
    public class ApiError
    {
        public ApiError() { }

        public ApiError(int errorCode ,string errorMessage) 
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; set; }
        public string  ErrorMessage { get; set; }


    }
}
