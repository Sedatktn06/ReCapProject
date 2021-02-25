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
            //CallWithId();
            /*
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine(customer.FirstName+" "+customer.LastName+" "+customer.CompanyName);
            }
            customerManager.Add(customer1);
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName+" "+customer.Id);
            }
            Rental rental = new Rental()
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Parse("07-03-2021")
            };
            */

            //AddRental();
            

        }

        private static void AddRental()
        {
            Rental rental2 = new Rental()
            {
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Parse("07-03-2021")
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental2).Message);
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
            brandManager.Add(new Brand { Id = 1, BrandName = "BMW" });
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
            colorManger.Add(new Color { Id = 1, ColorName = "Turuncu" });
            colorManger.Add(new Color { Id = 2, ColorName = "Mavi" });
            colorManger.Add(new Color { Id = 3, ColorName = "Siyah" });
            foreach (var color in colorManger.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName="Ticari"});
            carManager.Update(new Car { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName= "Hafif Ticari" });
            carManager.Update(new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 85, ModelYear = 2008, Description = "Kirli" ,CarName= "Otomabil" });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarAdd()
        {
            /*
            Car car1 = new Car() { Id=7,BrandId = 2, ColorId = 1, DailyPrice = 129, Description = "Güvenilir", ModelYear = 2008 };
            Car car2 = new Car() { Id = 4, BrandId = 1, ColorId = 1, DailyPrice = 111, Description = "Hasarlı", ModelYear = 2005 };
            Car car3 = new Car() { Id = 5,BrandId = 3, ColorId = 2, DailyPrice = 100, Description = "İki takla", ModelYear = 2002 };
            Car car4 = new Car() { Id = 6,BrandId = 2, ColorId = 3, DailyPrice = 180, Description = "Temiz", ModelYear = 2016 };
            */
            Car car5 = new Car() { BrandId = 4, ColorId = 2, CarName = "Otomobil", DailyPrice = 110, ModelYear = 2015, Description = "Temiz" };
            CarManager carManager = new CarManager(new EfCarDal());
            /*
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);
            carManager.Add(car4);
            */
            carManager.Add(car5);
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
