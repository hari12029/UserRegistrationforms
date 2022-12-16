using System;

namespace UserRegistration.Model
{

    public class ApiResponseModel
        {
            public dynamic Data { get; set; }
            public Exception Exception { get; set; }
            public string Message { get; set; }

            public ApiResponseModel(dynamic data, string message = "")
            {
                Data = data;
                Message = message;
                Exception = null;
            }

            public ApiResponseModel(Exception ex)
            {
                Data = null;
                Exception = ex;
                Message = "Fatal Error occured!";
            }

            public ApiResponseModel(string error)
            {
                Data = Exception = null;
                Message = error;
            }

            public ApiResponseModel()
            {
            }
        }
    }

