using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using CarPriceHonester.DAL;
using CarPriceHonester.Entity.Table;


namespace CarPriceHonester.Service.CarInfo
{
    public class CarInfoService : ICarInfoService
    {
        private readonly ICarInfoDAL _carInfoDal;

        public CarInfoService(ICarInfoDAL carInfoDal)
        {
            _carInfoDal = carInfoDal;
        }

        public IObservable<List<CarModel>> GetAllCarInfoSource()
        {
            return Observable.Return(_carInfoDal.GetAllCarInfo())
                             .Do((dalResult) =>
                             {
                                 if (dalResult.HasError) throw dalResult.Error;
                             })
                             .Select((dalResult) => dalResult.Data);
        }


        public IObservable<List<CarModel>> GetAllCarDetailInfoSource()
        {
            return Observable.Return(_carInfoDal.GetAllCarDetailInfo())
                   .Do((dalResult) =>
                   {
                       if (dalResult.HasError) throw dalResult.Error;

                   })
                   .Select((dalResult) => dalResult.Data);
        }


        public IObservable<CarDetailModel> GetCarDetailSource(int id)
        {
            return Observable.Return(id)
                   .Do((carId) =>
                   {
                       if (carId < 0)
                       {
                           throw new FormatException();
                       }

                   })
                   .Select(_carInfoDal.GetCarDetail)
                   .Do((carDatailDalResult) =>
                   {
                       if (carDatailDalResult.Error != null)
                       {
                           throw carDatailDalResult.Error;
                       }
                   })
                   .Select((dalResult) => dalResult.Data);
        }
    }
}
