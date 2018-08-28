using System;
using System.Collections.Generic;
using CarPriceHonester.Entity.Table;

namespace CarPriceHonester.Service.CarInfo
{
    public interface ICarInfoService
    {
        IObservable<List<CarModel>> GetAllCarInfoSource();

        IObservable<List<CarModel>> GetAllCarDetailInfoSource();

        IObservable<CarDetailModel> GetCarDetailSource(int id);
    }
}
