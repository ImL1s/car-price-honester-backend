using System;
namespace CarPriceHonester.Entity.CustomException
{
    public class FormatException: Exception
    {
        public override string ToString()
        {
            return "format error";
        }
    }
}
