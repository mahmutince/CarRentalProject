using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car) 
        {
            _carDal.Add(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c=> c.BrandId==brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c=> c.ColorId==colorId);
        }

        public List<Car> GetCarById(int carId)
        {
            return _carDal.GetAll(c=> c.CarId==carId);
        }
    }
}
