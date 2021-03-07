using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, IBrandService brandService, ICarImageService carImageService)
        {
            _carDal = carDal;
            _brandService = brandService;
            _carImageService = carImageService;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
            
        }

        [ValidationAspect(typeof(CarValidator))]

        public IResult Add(Car car) 
        {
            IResult result= BusinessRules.Run(
                CheckCarCountOfBrand(car.BrandId), //Bir markadan en fazla 15 araç olabilir.
                CheckBrandLimit() //En fazla 10 araç markası olabilir.7 
                );

            if (result==null)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult();
            
            
        }
        
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        { 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.ColorId==colorId), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId==carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==15)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IResult CheckBrandLimit()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 10)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();

        }

        public IResult CheckCarCountOfBrand(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarCountLimit);
            }
            return new SuccessResult();

        }

    
    }
}
