using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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

        //[SecuredOperation("Admin")]
        [CacheAspect]
        //[PerformanceAspect(0)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
            
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
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
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=> c.ColorId==colorId), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId==carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

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
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<100)
            {
                throw new Exception();
            }
            Add(car);
            return null;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId== carId), Messages.CarsListed);
        }
    }
}
