using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using CarPriceHonester.Entity.Constant;
using CarPriceHonester.Entity.modal;
using CarPriceHonester.Entity.Table;
using CarPriceHonester.Service.CarInfo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPriceHonester.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarInfoService _carInfoService;

        public CarController(ICarInfoService carInfoService)
        {
            _carInfoService = carInfoService;
        }

        [HttpGet]
        public async Task<object> All()
        {
            try
            {
                return await _carInfoService.GetAllCarDetailInfoSource().ToTask();
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await new Task<GenericResult>(
                    () => new GenericResult
                    {
                        Error = e.ToString(),
                        ErrorCode = HttpErrorCode.internalServerError
                    }
                );
            }

        }


        [HttpGet("[action]")]
        public async Task<object> AllCarDetail()
        {
            try
            {
                return await _carInfoService.GetAllCarDetailInfoSource().ToTask();
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await new Task<GenericResult>(
                    () => new GenericResult
                    {
                        Error = e.ToString(),
                        ErrorCode = HttpErrorCode.internalServerError
                    }
                );
            }
        }


        [HttpGet("[action]/{id}")]
        public async Task<object> Detail(int id)
        {
            try
            {
                return await _carInfoService.GetCarDetailSource(id).ToTask();
            }
            catch (Exception e)
            {
                Response.StatusCode = e is FormatException ?
                    (int)HttpStatusCode.BadRequest :
                    (int)HttpStatusCode.InternalServerError;

                var errorCode = e is FormatException ?
                    HttpErrorCode.fortmatError :
                                 HttpErrorCode.other;

                return await new Task<GenericResult>(
                    () => new GenericResult
                    {
                        Error = e.ToString(),
                        ErrorCode = errorCode
                    }
                );
            }
        }
    }
}
