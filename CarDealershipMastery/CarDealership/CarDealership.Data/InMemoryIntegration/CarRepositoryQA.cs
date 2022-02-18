using CarDealership.Models;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class CarRepositoryQA : ICarRepository
    {
        private List<Car> _cars = new List<Car>()
        {
            new Car()
            {
                CarId = 0,
                VIN = "AAA11111B22222222",
                ImgFileName = "inventory-0.png",
                Year = 2020,
                Mileage = 500,
                Price = 20000M,
                MSRP = 22500M,
                Description = "A simple car for your simpler life",
                IsSold = false,
                IsFeatured = true,
                ModelId = 0,
                InteriorId = 0,
                ColorId = 0,
                TypeId = 0,
                TransmissionId = 0,
                BodyStyleId = 0,
                Model = "Integra",
                Make = "Acura",
                Color = "Silver",
                Interior = "Black",
                Transmission = "Automatic"
            },
            new Car()
            {
                CarId = 1,
                VIN = "BBB22222C33333333",
                ImgFileName = "inventory-1.png",
                Year = 2010,
                Mileage = 90000,
                Price = 8500M,
                MSRP = 10000M,
                Description = "A simpler car for your graduation present",
                IsSold = true,
                IsFeatured = false,
                ModelId = 1,
                InteriorId = 1,
                ColorId = 1,
                TypeId = 1,
                TransmissionId = 1,
                BodyStyleId = 1,
                Make = "Buick",
                Model = "Encore",
                Color = "Gold",
                Interior = "White",
                Transmission = "Manual"
            },
            new Car()
            {
                CarId = 2,
                VIN = "CCC33333D44444444",
                ImgFileName = "inventory-2.png",
                Year = 2020,
                Mileage = 500,
                Price = 14000M,
                MSRP = 20000M,
                Description = "A simple car for your simpler life",
                IsSold = false,
                IsFeatured = false,
                ModelId = 0,
                InteriorId = 0,
                ColorId = 0,
                TypeId = 0,
                TransmissionId = 0,
                BodyStyleId = 0,
                Make = "Acura",
                Model = "Integra",
                Color = "Silver",
                Interior = "Black",
                Transmission = "Automatic"
            },
            new Car()
            {
                CarId = 3,
                VIN = "DDD44444E55555555",
                ImgFileName = "inventory-3.png",
                Year = 2010,
                Mileage = 50000,
                Price = 9500M,
                MSRP = 12500M,
                Description = "A simpler car for your graduation present",
                IsSold = true,
                IsFeatured = true,
                ModelId = 1,
                InteriorId = 1,
                ColorId = 1,
                TypeId = 1,
                TransmissionId = 1,
                BodyStyleId = 1,
                Make = "Buick",
                Model = "Encore",
                Color = "Gold",
                Interior = "White",
                Transmission = "Manual"
            },
            new Car()
            {
                CarId = 4,
                VIN = "AAAAAAAAAAAAAAAAA",
                ImgFileName = "inventory-4.png",
                Year = 2010,
                Mileage = 50000,
                Price = 9500M,
                MSRP = 12500M,
                Description = "A simpler car for your graduation present",
                IsSold = false,
                IsFeatured = true,
                ModelId = 1,
                InteriorId = 1,
                ColorId = 1,
                TypeId = 1,
                TransmissionId = 1,
                BodyStyleId = 1,
                Make = "Buick",
                Model = "Encore",
                Color = "Gold",
                Interior = "White",
                Transmission = "Manual"
            },
            new Car()
            {
                CarId = 5,
                VIN = "BBBBBBBBBBBBBBBBB",
                ImgFileName = "inventory-5.png",
                Year = 2010,
                Mileage = 50000,
                Price = 9500M,
                MSRP = 12500M,
                Description = "A simpler car for your graduation present",
                IsSold = false,
                IsFeatured = true,
                ModelId = 1,
                InteriorId = 1,
                ColorId = 1,
                TypeId = 1,
                TransmissionId = 1,
                BodyStyleId = 1,
                Make = "Buick",
                Model = "Encore",
                Color = "Gold",
                Interior = "White",
                Transmission = "Manual"
            },
        };
        public void Delete(int carId)
        {
            _cars.Remove(_cars.Where(c => c.CarId == carId).FirstOrDefault());
        }

        public Car GetById(int carId)
        {
            var car = _cars.Where(c => c.CarId == carId).FirstOrDefault();
            if (car == null)
                return new Car();
            else
                return car;
        }

        public Car GetDetails(int carId)
        {
            var car = _cars.Where(c => c.CarId == carId).FirstOrDefault();
            if (car == null)
                return new Car();
            else
                return car;
        }

        public List<Car> GetFeatured()
        {
            var found = from car in _cars
                        where car.IsFeatured == true && car.IsSold == false
                        select car;

            return found.ToList();
        }

        public int GetNextCarId()
        {
            return _cars.Max(m => m.CarId) + 1;
        }

        public void Insert(Car car)
        {
            car.CarId = GetNextCarId();
            _cars.Add(car);
        }

        public List<Car> SearchAll(SearchParameters parameters)
        {
            if (parameters.YearParameter == 0)
            {
                var found = from car in _cars
                            where (car.IsSold == false) &&
                                (car.Make.Contains(parameters.Parameter) ||
                                car.Model.Contains(parameters.Parameter)) &&
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) &&
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
            else
            {
                var found = from car in _cars
                            where (car.IsSold == false) && 
                                (car.Year == parameters.YearParameter) && 
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) && 
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
        }

        public List<Car> SearchNew(SearchParameters parameters)
        {
            if (parameters.YearParameter == 0)
            {
                var found = from car in _cars
                            where (car.IsSold == false) &&
                                (car.TypeId == 0) &&
                                (car.Make.Contains(parameters.Parameter) ||
                                car.Model.Contains(parameters.Parameter)) &&
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) &&
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
            else
            {
                var found = from car in _cars
                            where (car.IsSold == false) &&
                                (car.TypeId == 0) &&
                                (car.Year == parameters.YearParameter) &&
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) &&
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
        }

        public List<Car> SearchUsed(SearchParameters parameters)
        {
            if (parameters.YearParameter == 0)
            {
                var found = from car in _cars
                            where (car.IsSold == false) &&
                                (car.TypeId == 1) &&
                                (car.Make.Contains(parameters.Parameter) ||
                                car.Model.Contains(parameters.Parameter)) &&
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) &&
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
            else
            {
                var found = from car in _cars
                            where (car.IsSold == false) &&
                                (car.TypeId == 1) &&
                                (car.Year == parameters.YearParameter) &&
                                (car.Price >= parameters.PriceMin && car.Price <= parameters.PriceMax) &&
                                (car.Year >= parameters.YearMin && car.Year <= parameters.YearMax)
                            orderby car.MSRP descending
                            select car;
                return found.ToList();
            }
        }

        public void Update(Car car)
        {
            _cars.Remove(_cars.Where(c => c.CarId == car.CarId).FirstOrDefault());
            _cars.Add(car);
        }
    }
}
