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
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("---Tüm araçları göster---");
            GetAll(carManager);
            Console.WriteLine("---Renk id ile araç göster---");
            GetByColorId(carManager,4);
            Console.WriteLine("---Marka id ile araç göster---");
            GetByBrandId(carManager,1);
            Console.WriteLine("---Araç id ile araç göster---");
            GetByCarId(carManager,5);

            //carManager.Add(new Car { BrandId = 4, ColorId = 4, DailyPrice = 120, Description = "Sedan", ModelYear = "2016" });
            //carManager.Update(new Car { CarId = 10, BrandId = 4, ColorId = 4, DailyPrice = 120, Description = "Hatchback",ModelYear = "2016" });
            


        }

        //InMemory için yazdıklarım
        private static void ForInMemory()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("---Tüm araçları göster---");
            GetAll(carManager);
            Console.WriteLine("--- 5 no Araç ekle---");
            carManager.Add(new Car { CarId=5,BrandId = 2, ColorId = 3, DailyPrice = 220, Description = "Coupe", ModelYear = "2020" });
            GetAll(carManager);
            Console.WriteLine("---5 nolu aracı güncelle---");
            carManager.Update(new Car { CarId = 5, BrandId = 2, ColorId = 2, DailyPrice = 120, Description = "Coupe", ModelYear = "2020" });
            GetAll(carManager);
            Console.WriteLine("---Sadece 5 nolu aracı göster---");
            //GetById(carManager, 5);
            Console.WriteLine("---5 nolu aracı sil---");
            carManager.Delete(new Car { CarId = 5 });
            GetAll(carManager);
        }

        static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
        }

        static void GetByColorId(CarManager carManager, int colorId)
        {
            foreach (var car in carManager.GetCarsByColorId(colorId))
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
        }
        static void GetByBrandId(CarManager carManager, int brandId)
        {
            foreach (var car in carManager.GetCarsByBrandId(brandId))
            { 
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId,car.BrandId,car.ColorId,car.DailyPrice,car.ModelYear,car.Description);
            }
        }
        static void GetByCarId(CarManager carManager, int cardId)
        {
            foreach (var car in carManager.GetCarById(cardId))
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
        }
    }
}
