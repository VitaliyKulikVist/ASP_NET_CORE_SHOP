using ASP_NET_CORE_SHOP.DATA.Interfaces;
using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Moks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();//Створення приватної змінної з категоріями, які можна буде використати при описі кожного нового товару (авто)
        public IEnumerable<Car> Cars

            // private readonly ICarsCategory _carsCategory;
            //private static List<Car> _cars = new List<Car>//list masive
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla Модел S",
                        shortDesc = "Білий автомобіль Tesla",
                        longDesc = "Швидкий з середнім запасом ходу",
                        img = "/img/Tesla Модел S.jpg",
                        price = 45000,
                        isFavorite = true,
                        avalible = 20,
                        Category=_carsCategory.AllCategories.First() //говоримо що Category=_carsCategory.AllCategories.First() категорія буде братись з всіх категорії як перша
                    },
                    new Car
                    {
                        name = "Cybertruck",
                        shortDesc = "Футуристично виглядаючий автомобіль",
                        longDesc = "Геометрично правильний автомобіль для дивування прохожих",
                        img = "/img/Cybertruck.jpg",
                        price = 50000,
                        isFavorite = true,
                        avalible = 30,
                        Category=_carsCategory.AllCategories.First() //дане авто відноситься до останьої кактегорій
                    },
                    new Car
                    {
                        name = "BMW X7",
                        shortDesc = "Громіздкий автомобіль на дизельному палеві",
                        longDesc = "Великий 4х4 кросовер для їзди по бездоріжжю з вмістимим багажником",
                        img = "/img/BMW X7.jpg",
                        price = 10000,
                        isFavorite = true,
                        avalible = 30,
                        Category=_carsCategory.AllCategories.Last() //дане авто відноситься до останьої кактегорій
                    }
                };
            }
        }



        public IEnumerable<Car> getFavorCars 
        { get ;set ; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
