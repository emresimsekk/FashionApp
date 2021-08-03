using System.Collections.Generic;

namespace FashionApp.Shared.Utilities.Result.Concrete
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int Status { get; set; }
        public bool isShow { get; set; }
    }
}
