using ASP_NET_CORE_SHOP.DATA.Interfaces;
using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Repository
{
    public class CategoryRepository : ICarsCategory//Підключити в юзінгах, і не забути ПКМ---"Реалізовати інтерфейс"
    {

        //це все що потрібно буде для роботи з БД
        private readonly AppDBcontent appDBcontent;//create AppDBcontent змінна для роботи з файлом AppDBcontent (для роботи з бд)
        public CategoryRepository()
        {
                this.appDBcontent = appDBcontent;
        }
        /// <summary>
        /// ///////////////////////////////////////////////////
        /// </summary>




        public IEnumerable<Category> AllCategories => appDBcontent.Category;//Просто отримуємо всі категорії
    }
}
