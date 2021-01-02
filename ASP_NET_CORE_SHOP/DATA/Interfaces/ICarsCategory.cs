using ASP_NET_CORE_SHOP.DATA.Models;//підключивши моделі в інтерфейсі, можемо спокійно використовувати всі функції, змінні даної можеді
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Interfaces
{//Даний інтерфейс для отримання всіх моделей категорій 
    interface ICarsCategory
    {
        //Пропишемо функції які будуть відбуватись в інтерфуесі
        IEnumerable<Category> AllCategories { get; }//Дана функція необхідна для відображення всіх категорій(отримати)
                                                    //Буде помилка, необхідно Підключити(прописати) using ASP_NET_CORE_SHOP.DATA.Models; (або нажати на лампочку і вибрати і воно саме підключить)

    }
}
