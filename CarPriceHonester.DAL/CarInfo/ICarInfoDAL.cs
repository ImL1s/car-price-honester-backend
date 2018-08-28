using System;
using System.Collections.Generic;
using CarPriceHonester.Entity.modal;
using CarPriceHonester.Entity.Table;

namespace CarPriceHonester.DAL
{
    public interface ICarInfoDAL
    {
        DalResult<List<CarModel>> GetAllCarInfo();

        DalResult<List<CarModel>> GetAllCarDetailInfo();

        DalResult<CarDetailModel> GetCarDetail(int id);
    }
}
