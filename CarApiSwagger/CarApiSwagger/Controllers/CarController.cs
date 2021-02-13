using CarApiSwagger.Engine;
using CarApiSwagger.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApiSwagger.Controllers
{
    [ApiController]
    [Route("[controller]")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CarController : ControllerBase

    {
        private readonly ICarEngine carEngine;

        public CarController(ICarEngine carEngine)
        {
            this.carEngine = carEngine;
        }

        /// <summary>
        /// Get all cars from data.
        /// </summary>
        [HttpGet]
        public IEnumerable<CarModel> Get()
        {
            return this.carEngine.GetCars();
        }

        //public ActionResult<int> GetCarCount()
        //{
        //    return this.carEngine.GetCars().Count();
        //}

        /// <summary>
        /// Added car brand and specific model.
        /// </summary>
        /// <param name="carModel"></param> 
        [HttpPost]
        public ActionResult<string> AddCar([FromBody]CarModel carModel)
        {
            bool isCarRemoved = this.carEngine.AddCar(carModel);
            return Ok("Car was added successfully");
        }

        /// <summary>
        /// Get a specific car by car brand.
        /// </summary>
        /// <param name="carBrand"></param> 
        [HttpGet("{carBrand}")]
        public ActionResult<CarModel> GetCarByBrand(string carBrand)
        {
            try
            {
                CarModel car = this.carEngine.GetCarByBrand(carBrand);
                if (car != null)
                {
                    return car;
                }
                return Ok("Car not fount");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Deletes a specific car by car brand.
        /// </summary>
        /// <param name="carBrand"></param> 
        [HttpDelete("{carBrand}")]
        public ActionResult<string> DeleteCar(string carBrand)
        {
            try
            {
                bool isCarRemoved = this.carEngine.DeleteCar(carBrand);
                if (isCarRemoved)
                {
                    return Ok("Car was deleted successfully");
                }
                return Ok("Car not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
