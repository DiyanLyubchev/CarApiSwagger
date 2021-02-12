using CarApiSwagger.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarApiSwagger.Engine
{
    public interface ICarEngine
    {
        List<CarModel> GetCars();
        CarModel GetCarByBrand(string carBrand);
        bool DeleteCar(string carBrand);
        bool AddCar(CarModel carModel);
    }

    public class CarEngine : ICarEngine
    {
        private readonly string path = @"Data\cars.json";

        public List<CarModel> GetCars()
        {
            string carsJson = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<CarModel>>(carsJson);
        }

        public CarModel GetCarByBrand(string carBrand)
        {
            CarModel currentCar = this.GetCars()
                .FirstOrDefault(carBrad => carBrad.Brand.ToUpper().Contains(carBrand.ToUpper())); 

            return currentCar;
        }

        public bool DeleteCar(string carBrand)
        {
            List<CarModel> cars = this.GetCars();

            CarModel currentCar = this.GetCars()
               .FirstOrDefault(carBrad => carBrad.Brand.ToUpper().Contains(carBrand.ToUpper()));

            if (currentCar == null)
            {
                return false;
            }

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Brand == currentCar.Brand)
                {
                    cars.RemoveAt(i);
                    break;
                }
            }

            string jsonCar = JsonSerializer.Serialize(cars);

            File.WriteAllText(path, jsonCar);

            return true;
        }

        public bool AddCar(CarModel carModel)
        {
            List<CarModel> cars = this.GetCars();
            cars.Add(carModel);

            string jsonCar = JsonSerializer.Serialize(cars);
            File.WriteAllText(path, jsonCar);

            return true;
        }
    }
}
