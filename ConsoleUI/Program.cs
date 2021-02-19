using System;
using Business.Concrete;
using DataAccess.Concrete.InMemoryCarDal;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("---Tüm araçları göster---");
            GetAll(carManager);
            Console.WriteLine("---5 nolu araç ekle---");
            carManager.Add(new Car { CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 100, Description = "Coupe", ModelYear = "2020" });
            GetAll(carManager);
            Console.WriteLine("---5 nolu aracı güncelle---");
            carManager.Update(new Car { CarId = 5, BrandId = 2, ColorId = 2, DailyPrice = 120, Description = "Coupe", ModelYear = "2020" } );
            GetAll(carManager);
            Console.WriteLine("---Sadece 5 nolu aracı göster---");
            GetById(carManager, 5);
            Console.WriteLine("---5 nolu aracı sil---");
            carManager.Delete(new Car {CarId=5 });
            GetAll(carManager);

        }

        static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç No: " + car.CarId + " Günlük Ücret: " + car.DailyPrice + " Tanım: " + car.Description + " Renk: " + car.ColorId);
            }
        }

        static void GetById(CarManager carManager, int carId)
        {
            foreach (var car in carManager.GetById(carId))
            {
                Console.WriteLine("Araç No: " + car.CarId + " Günlük Ücret: " + car.DailyPrice + " Tanım: " + car.Description + " Renk: " + car.ColorId);
            }
        }
    }
}
