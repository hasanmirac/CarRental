using Business.Concrete;
using Business.Constans;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.GetRentalDetails();
            //foreach (var car in result.Data)
            //{
            //    Console.WriteLine(car);
            //}

            //UserAdded();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.RentalId + " " + rental.FirstName + " " + rental.BrandName +  " " + rental.RentDate);
            }
            Console.WriteLine(result.Message);

        }

        private static void UserAdded()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                UserId = 1,
                FirstName = "Ayşe",
                LastName = "Çınar",
                Email = "ayse@hotmail.com",
                Password = "12345"

            });
            Console.WriteLine(Messages.UserAdded);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
