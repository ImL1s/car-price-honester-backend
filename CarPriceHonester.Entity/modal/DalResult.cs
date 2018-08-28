using System;
namespace CarPriceHonester.Entity.modal
{
    public class DalResult<T> where T : class
    {
        public DalResult() { }

        public DalResult(T data) : this(data, null) { }

        public DalResult(Exception error) : this(default(T), error) { }


        public DalResult(T data, Exception error)
        {
            this.Data = data;
            this.Error = error;
        }

        public T Data { get; set; }
        public Exception Error { get; set; }
        public bool HasError => Error != null;
    }
}
