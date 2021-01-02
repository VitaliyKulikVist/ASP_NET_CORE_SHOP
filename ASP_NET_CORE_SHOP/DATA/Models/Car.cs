using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Models
{
    public class Car//Цей товар(машина) може мати лише 1 категрію 
    {
        public int id { set; get; }//id конкретного авто(потрібно буде для БД)
        public string name { set; get; }//name автомобіля
        public string shortDesc { set; get; }//Малий опис
        public string longDesc { set; get; }//Двогий опис
        public string img { set; get; }//Зображення(будемо вказувати URL адресу по якій буде доступне зображення
        public ushort price { set; get; }//Ціна             (тип даних  ushort  не дає ціні бути зі знаком [-]    )
        public bool isFavorite { set; get; }//якщо тру(1) тоді буде відображатись на головній сторінці в меню "найкращі товари" якщо фолс(0) тоді не буде
        public int avalible { set; get; }//Скільки штук товару лишилось
        public int categoryID { set; get; }//Це поле присвоїть даний обєкт(товар\авто) до певної категорії(такий собі звязок)       вказавши цифру ми відразу скажемо що це зав категорія авто
        public virtual Category Category { set; get; }//Пере створюємо обєкт зі всіма полями які є в моделі [Category]

    }
}
