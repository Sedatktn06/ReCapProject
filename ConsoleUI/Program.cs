using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandAdd();
            //CarUpdate();
            //CarAdd();
            //ColorAdd();
            //CarDetails();
            CallWithId();

        }

        private static void CallWithId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(2);
            Console.WriteLine(result.Data.CarName);
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 1, BrandName = "BMW" });
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }

        private static void ColorAdd()
        {
            ColorManger colorManger = new ColorManger(new EfColorDal());
            colorManger.Add(new Color { ColorId = 1, ColorName = "Turuncu" });
            colorManger.Add(new Color { ColorId = 2, ColorName = "Mavi" });
            colorManger.Add(new Color { ColorId = 3, ColorName = "Siyah" });
            foreach (var color in colorManger.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName="Ticari"});
            carManager.Update(new Car { CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName= "Hafif Ticari" });
            carManager.Update(new Car { CarId = 4, BrandId = 2, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName= "Otomabil" });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarAdd()
        {
            Car car1 = new Car() { CarId=7,BrandId = 2, ColorId = 1, DailyPrice = 129, Description = "Güvenilir", ModelYear = 2008 };
            Car car2 = new Car() { CarId = 4, BrandId = 1, ColorId = 1, DailyPrice = 111, Description = "Hasarlı", ModelYear = 2005 };
            Car car3 = new Car() { CarId = 5,BrandId = 3, ColorId = 2, DailyPrice = 100, Description = "İki takla", ModelYear = 2002 };
            Car car4 = new Car() { CarId = 6,BrandId = 2, ColorId = 3, DailyPrice = 180, Description = "Temiz", ModelYear = 2016 };
                                
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
