using FashionApp.Shared.Utilities.Result.ComplexTypes;
using System;

namespace FashionApp.Shared.Utilities.Result.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }

        public Exception Exception { get; }
    }
}
