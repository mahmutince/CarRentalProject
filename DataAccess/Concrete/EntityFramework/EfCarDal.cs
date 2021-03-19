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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDatabaseContext context =new CarDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join clr in context.Colors
                             on c.ColorId equals clr.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             //join i in context.CarImages
                             //on c.CarId equals i.CarId
                             select new CarDetailDto
                             { CarId = c.CarId, BrandName = b.BrandName, ColorName = clr.ColorName, DailyPrice = c.DailyPrice,
                                 Description = c.Description, ModelYear = c.ModelYear,
                                 ImagePath= (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault() };
                return result.ToList();

            }
        }
    }
}
