using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemoryCarDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
   
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2016",Description="SUV"},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=120,ModelYear="2018",Description="Sedan"},
                new Car{CarId=3,BrandId=2,ColorId=1,DailyPrice=80,ModelYear="2014",Description="Sedan"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=160,ModelYear="2020",Description="SUV"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete= _cars.SingleOrDefault(c=> c.CarId==car.CarId);
            _cars.Remove(carDelete);
        }

       

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
            carUpdate.ModelYear = car.ModelYear;

        }
    }
}
