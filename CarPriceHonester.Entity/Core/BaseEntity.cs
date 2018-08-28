using System;

namespace CarPriceHonester.Entity.Core
{
    public abstract class BaseEntity<T>

    {
        public DateTime CreateTime { get; set; }

        public T Id { get; set; }

        BaseEntity()
        {
            CreateTime = DateTime.Now;
        }
    }
}
