using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //ColorTest();
            //CarManagerTest();
            //CarDetailsDtoTest();
            //RentalListTest();
            //UserTest();
            //RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addRent = rentalManager.Add(new Rental { CarId = 3, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = null });
            Console.WriteLine(addRent.Message);


            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentalId);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine("Id: {0} İsim: {1}", item.Id, item.FirstName);
            }
        }

        private static void RentalListTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("RentalId: {0} CarID: {1} CustomerId: {2} RentDate: {3} ReturnDate: {4}"
                    , rental.RentalId, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        //private static void CarDetailsDtoTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetCarDetails();
        //    if (result.Success==true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine("Araç No: {0}\n Marka: {1} \n  Renk: {2} \n   Günlük Ücret: {3}\n", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);

        //        }
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
            
        //}

        //private static void CarManagerTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine("\n---Tüm araçları göster---\n");
        //    foreach (var car in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
        //    }
        //    Console.WriteLine("\n---Renk id 1 olan araçları göster---\n");
        //    foreach (var car in carManager.GetCarsByColorId(1).Data)
        //    {
        //        Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
        //    }
        //    Console.WriteLine("\n---Marka id 1 olan araçları göster---\n");
        //    foreach (var car in carManager.GetCarsByBrandId(1).Data)
        //    {
        //        Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
        //    }
        //    Console.WriteLine("\n---Araç id 4 olan aracı göster---\n");
        //    var carById = carManager.GetById(4).Data;
        //    Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", carById.CarId, carById.BrandId, carById.ColorId, carById.DailyPrice, carById.ModelYear, carById.Description);

        //}

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Renk Id: {0}  Renk: {1}", color.ColorId, color.ColorName);
            }
        }



        
    }
}
