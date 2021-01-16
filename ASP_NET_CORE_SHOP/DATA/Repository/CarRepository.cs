using ASP_NET_CORE_SHOP.DATA.Interfaces;
using ASP_NET_CORE_SHOP.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Repository
{
    public class CarRepository : IAllCars//Підключаєм наслідування від інтерфейсу IAllCars потім пкм---"Реализовать все функции интерфейса"
    {

        private readonly AppDBcontent appDBcontent;//create AppDBcontent змінна для роботи з файлом AppDBcontent (для роботи з бд)

        public CarRepository(AppDBcontent appDBcontent)//конструктор який необхідний для БД!
        {
            this.appDBcontent = appDBcontent;
        }
        public IEnumerable<Car> Cars => appDBcontent.Car.Include(c => c.Category);//отримання даних з файлу AppDBcontent

        public IEnumerable<Car> getFavorCars => appDBcontent.Car.Where(z => z.isFavorite).Include(c => c.Category);//Отримуємо всі обєкти, в яких isFavorite == true

        public Car getObjectCar(int carId) => appDBcontent.Car.FirstOrDefault(z => z.id == carId);//Вибираємо лишее той обєкт в якого ід == карІд

    }
}
