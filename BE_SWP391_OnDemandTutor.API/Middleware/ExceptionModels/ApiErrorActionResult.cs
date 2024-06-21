using System;
namespace BE_SWP391_OnDemandTutor.API.Middleware.ExceptionModels;

    public class ApiErrorActionResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public List<ValidationErrorModel> Errors { get; set; }
    }

    public class ValidationErrorModel
    {
        public ValidationErrorModel(string errorMessage, string propertyName = null, string errorCode = null)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }

