using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarId=1, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=2000, Description="Dağ arabası" },
                new Car { CarId=2, BrandId=1, ColorId=3, ModelYear=2021, DailyPrice=4000, Description="Yarış arabası" },
                new Car { CarId=3, BrandId=2, ColorId=2, ModelYear=2011, DailyPrice=700,  Description="Traktör" },
                new Car { CarId=4, BrandId=4, ColorId=4, ModelYear=2019, DailyPrice=1500, Description="Karavan" },
                new Car { CarId=5, BrandId=3, ColorId=5, ModelYear=2017, DailyPrice=1000, Description="Panelvan" },

            };
        }

        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
