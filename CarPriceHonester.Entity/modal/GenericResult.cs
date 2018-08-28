using System;
namespace CarPriceHonester.Entity.modal
{
    public class GenericResult
    {
        public GenericResult()
        {
        }

        public string Data { get; set; }

        public string Error { get; set; }

        public int ErrorCode { get; set; }
    }
}
