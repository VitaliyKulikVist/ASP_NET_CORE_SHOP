using ASP_NET_CORE_SHOP.DATA.Models;
using Microsoft.EntityFrameworkCore; //Бібліотека для наслідування класу DbContext Microsoft.EntityFrameworkCore
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA
{//в цьому класі реєструємо всі таблички які будуть в бд
    public class AppDBcontent : DbContext
    {
        public AppDBcontent(DbContextOptions<AppDBcontent> options) : base(options)//Конструктор який отримує і передає себе як options
        {

        }

        public DbSet<Car> Car { get; set;}//те ж саме що в інтерфейсі тільки на цей раз функції для витягування даних з БД
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> shopCartItems { get; set; }


    }
}
