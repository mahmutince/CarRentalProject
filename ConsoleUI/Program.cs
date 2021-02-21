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

            //carManager.Add(new Car { BrandId = 4, ColorId = 4, DailyPrice = 120, Description = "Sedan", ModelYear = "2016" });
            //carManager.Update(new Car { CarId = 10, BrandId = 4, ColorId = 4, DailyPrice = 120, Description = "Hatchback",ModelYear = "2016" });

            //ColorTest();
            //CarManagerTest();
            //CarDetailsDtoTest();

        }

        private static void CarDetailsDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araç No: {0}\n Marka: {1} \n  Renk: {2} \n   Günlük Ücret: {3}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice);

            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\n---Tüm araçları göster---\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.WriteLine("\n---Renk id 1 olan araçları göster---\n");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.WriteLine("\n---Marka id 1 olan araçları göster---\n");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.WriteLine("\n---Araç id 4 olan aracı göster---\n");
            var carById = carManager.GetCarById(4);
            Console.WriteLine("Araç No: {0} Marka: {1} Renk: {2} Günlük Ücret: {3} Model Yılı: {4} Tanım: {5}", carById.CarId, carById.BrandId, carById.ColorId, carById.DailyPrice, carById.ModelYear, carById.Description);

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk Id: {0}  Renk: {1}", color.ColorId, color.ColorName);
            }
        }



        
    }
}
