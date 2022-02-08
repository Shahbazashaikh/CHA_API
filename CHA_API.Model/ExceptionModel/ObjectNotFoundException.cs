using System;

namespace CHA_API.Model.ExceptionModel
{
    public class ObjectNotFoundException : Exception
    {
        public string FileName { get; set; }

        public string MethodName { get; set; }

        public object InputParameter { get; set; }

        public ObjectNotFoundException() : base() { }

        public ObjectNotFoundException(string message) : base(message) { }

        public ObjectNotFoundException(string message, string fileName, string methodName, object inputParameter) : base(message)
        {
            FileName = fileName;
            MethodName = methodName;
            InputParameter = inputParameter;
        }

        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public ObjectNotFoundException(string message, Exception innerException, string fileName, string methodName, object inputParameter = null) : base(message, innerException)
        {
            FileName = fileName;
            MethodName = methodName;
            InputParameter = inputParameter;
        }
    }
}
