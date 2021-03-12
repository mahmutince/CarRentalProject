using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarDatabaseContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDatabaseContext context=new CarDatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ct in context.Customers
                             on r.CustomerId equals ct.CustomerId
                             select new RentalDetailDto { RentalId = r.RentalId, BrandName = b.BrandName, CustomerName = ct.CustomerName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();

                            
                            
            }
        }
    }
}
