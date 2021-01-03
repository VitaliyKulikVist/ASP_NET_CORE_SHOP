using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Models
{
    public class Category//В цій категорії є великий список товарів які в неї входять
    {
        public int id { set; get; }//Ід самої категорії(порядковий номер, в залежності скільки тих категорій буде)
        public string categoryName { set; get; }//Імя категорії
        public string desc { set; get; }//Опис категорії
        public List<Car> Сars { set; get; }//привязали дану модель Category до великої колекції моделей Car


    }
}
