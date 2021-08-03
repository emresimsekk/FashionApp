using FashionApp.Shared.Utilities.Result.ComplexTypes;

namespace FashionApp.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
