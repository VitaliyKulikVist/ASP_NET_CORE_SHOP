using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_SHOP.DATA.Models
{
    public class ShopCart
    {
        //Создамо конструктор для підключення до бд
        private readonly AppDBcontent appDBcontent;//create AppDBcontent змінна для роботи з файлом AppDBcontent (для роботи з бд)

        public ShopCart(AppDBcontent appDBcontent)//конструктор який необхідний для БД!
        {
            this.appDBcontent = appDBcontent;
        }
        public string ShopCardId { get; set; }//поле ідентичне як і в ShopCartItem.cs типу звязок
        public List<ShopCartItem> listshopItems { get; set; }

        //Створюємо Static функції, бо будемо визивати їх пізніше
        public static ShopCart GetCart(IServiceProvider service)//функція на перевірку чи добавляв користувач товар в корзину
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;//Створюємо обєкт, за допомого якого можемо працювати з сесіями
            var context = service.GetService<AppDBcontent>();//Дасть змогу отримувати табличкі і працювати з БД
            //В цю строку будуемо поміщати ід корзини(якщо користувач не добавляв ні одного товару в корзину, ми створимо нову сесію і товари будуть в одній корзині)
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); //В сесіях взяти елемент в якому ключ CartId, і перевіряємо = якщо не існує CartId, тоді будемо створювати новий
            session.SetString("CartId",shopCartId);//в якості ключа для нової сесії буде CartId а в якості значення shopCartId
            return new ShopCart(context) { ShopCardId = shopCartId };//(чи знаємо ми з якою корзиною ми працюємо якщо ні то створюємо і вертаємо)
        }

        public void AddToCart(Car car,int  amout)//Функція яка буде дозволяти добавляти товари в корзину
        {
            this.appDBcontent.shopCartItems.Add(new ShopCartItem
            {
                shopCardId = ShopCardId,//shopCardId з файлу ShopCartItem   a   ShopCardId з цього файлу зверух [public string ShopCardId]
                car = car,
                price = car.price
            });
            appDBcontent.SaveChanges();
        }

        //функція для відображення всіх товарів в корзині
        public List<ShopCartItem> GetShopItems()//повертає список на основі можелі ShopCartItem
        {
            return appDBcontent.shopCartItems.Where(c => c.shopCardId==ShopCardId).Include(s => s.car).ToList();//Умова: вибрати лише ті елементи в яких ід корзини = ід корзини яка в сесії, всі обєкти машини занести в ліст
        }




}
}
