using ASP_NET_CORE_SHOP.DATA.Interfaces;//Не забути підлкючити інтерфейс для роботи з його функціями
using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Moks
{
    public class MockCategory : ICarsCategory//Лампочка---[підключити інтерфейс]        потім       Лампочка на імен------[реалізувати інтерфейс]           залежність(реалізація) даного класу від інтерфейсу
    {
        public IEnumerable<Category> AllCategories
        {
            get //Функція "повернення"
            {
                return new List<Category>//це для роботи без БД
                {
                    new Category{categoryName="Електро мобілі", desc="Приводяться в рух, за допомогою електричного струму" },
                    new Category{categoryName="Бензинові автомобілі", desc="Приводяться в рух, за допомогою бензину" },
                    new Category{categoryName="Дизельні автомобілі", desc="Приводяться в рух, за допомогою Дизельного палива" },
                    new Category{categoryName="Бензини водородного синтезу", desc="Приводяться в рух, за допомогою електролітичних конвекцій з подальшим видобутком водороду" },
                };
            }
            
            set//Функція задання
            {

            }
        }
    }
}
