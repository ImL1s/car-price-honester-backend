using System;
using System.Collections.Generic;
using System.Linq;
using CarPriceHonester.Entity.modal;
using CarPriceHonester.Entity.Table;
using CarPriceHonester.Models.Context;

namespace CarPriceHonester.DAL
{
    public class CarInfoDAL : ICarInfoDAL
    {
        readonly MainDbContext _dbContext;


        public CarInfoDAL(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DalResult<List<CarModel>> GetAllCarInfo()
        {
            try
            {
                var carInfoList = _dbContext.Cars.AsParallel().ToList();
                return new DalResult<List<CarModel>>(carInfoList);
            }
            catch (Exception e)
            {
                return new DalResult<List<CarModel>>(e);
            }
        }


        public DalResult<List<CarModel>> GetAllCarDetailInfo()
        {
            try
            {
                var models = _dbContext.Cars.Select(model => model);
                var list = new List<CarModel>();
                foreach (var car in models)
                {
                    car.Detail = _dbContext.CarsDetail.Where(model => model.Id == car.Id).First();
                    list.Add(car);
                }
                return new DalResult<List<CarModel>>(list, null);
            }
            catch (Exception e)
            {
                return new DalResult<List<CarModel>>(null, e);
            }
        }


        public DalResult<CarDetailModel> GetCarDetail(int id)
        {
            try
            {
                var result = _dbContext.CarsDetail.Where(model => model.Id == id).First();
                return new DalResult<CarDetailModel>
                {
                    Data = result
                };
            }
            catch (Exception e)
            {
                return new DalResult<CarDetailModel>
                {
                    Data = null,
                    Error = e
                };
            }
        }
    }
}
