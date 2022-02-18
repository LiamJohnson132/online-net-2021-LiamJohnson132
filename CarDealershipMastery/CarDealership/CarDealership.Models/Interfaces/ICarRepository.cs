using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface ICarRepository
    {
        void Insert(Car car);
        void Update(Car car);
        List<Car> SearchAll(SearchParameters parameters);
        List<Car> SearchUsed(SearchParameters parameters);
        List<Car> SearchNew(SearchParameters parameters);
        Car GetDetails(int carId);
        List<Car> GetFeatured();
        void Delete(int carId);
        Car GetById(int carId);
        int GetNextCarId();
    }
}
