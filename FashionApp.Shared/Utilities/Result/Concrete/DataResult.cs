using FashionApp.Shared.Utilities.Result.Abstract;
using FashionApp.Shared.Utilities.Result.ComplexTypes;
using System;

namespace FashionApp.Shared.Utilities.Result.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, bool isSuccessful)
        {
            ResultStatus = resultStatus;
            Message = message;
            IsSuccessful = isSuccessful;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
            Exception = exception;
        }
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public bool IsSuccessful { get; }
        public Exception Exception { get; }
    }
}
