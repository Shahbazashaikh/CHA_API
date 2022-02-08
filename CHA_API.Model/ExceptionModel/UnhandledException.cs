using System;

namespace CHA_API.Model.ExceptionModel
{
    public class UnhandledException : Exception
    {
        public string FileName { get; set; }

        public string MethodName { get; set; }

        public object InputParameter { get; set; }

        public int StatusCode { get; set; }

        public UnhandledException() : base() { }

        public UnhandledException(string message) : base(message) { }

        public UnhandledException(string message, string fileName, string methodName, object inputParameter = null, int statusCode = 0) : base(message)
        {
            FileName = fileName;
            MethodName = methodName;
            InputParameter = inputParameter;
            StatusCode = statusCode;
        }

        public UnhandledException(string message, Exception innerException) : base(message, innerException) { }

        public UnhandledException(string message, Exception innerException, string fileName, string methodName, object inputParameter = null, int statusCode = 0) : base(message, innerException)
        {
            FileName = fileName;
            MethodName = methodName;
            InputParameter = inputParameter;
            StatusCode = statusCode;
        }
    }
}
