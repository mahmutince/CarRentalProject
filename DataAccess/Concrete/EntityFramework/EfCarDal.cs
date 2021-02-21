using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDataBaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDataBaseContext context =new CarDataBaseContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors
                             on c.ColorId equals clr.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto {CarId=c.CarId,BrandName=b.BrandName,ColorName=clr.ColorName,DailyPrice=c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
