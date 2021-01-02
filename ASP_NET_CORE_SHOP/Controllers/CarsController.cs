﻿using ASP_NET_CORE_SHOP.DATA.Interfaces;//Підключаємо інтерфейс
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.Controllers
{
    public class CarsController: Controller//Наслідуємо Controller через   -----  using Microsoft.AspNetCore.Mvc    -----    через хелп добавляємо залежність
        //Тут бубудть функції при виклику яких буде повертатись тип даних як "Нью резалт" (це тип даних який повертає результат у вигляді HTML сторінки)
        //Нам потрібна HTML сторінка в яку ми будемо пеередавати товари(машинуи) які будуть на сайті і щоб отримати ці товари необхідно створити певний конструктор який встановлюватиме дані
        //По двом інтерфейсам
    {
        private readonly IOllCars _allCars;             //В ці змінні які беруться з інтерфейсів потім будемо записувати певні данні
        private readonly ICarsCategory _allCategories;  //змінні на інтрефейси (оскільки в "стартапі" є звязок інтерфейсів з класами які реалізують то самі інтерфейси мають в собі І класи також

        //Створюємо конструктор
        public CarsController (IOllCars iollcars, ICarsCategory icarscat)//Не забути поставити інтерфейс як паблік бо не має доступу до цих змінних(типу різнобой прав досутпу)
        {//коли ми передаватимемо інтерфейс то і передаватимемо колас який реалізовує цей інтерфейс
            _allCars = iollcars;//змінній інтерфейсу, присвоюємо все що буде передаватись
            _allCategories = icarscat;
        }

        public ViewResult Name_List()//Повертатиме результат а саме список всіх товарів             коли ми будемо обращатьсь до даної функції ми будемо отримувати HTML сторінку з всіми авто
        {
            var cars = _allCars.Cars;//Змінній присвоюємо всі автомобілі з інтерфейсу IOllCars 
            return View(cars); //цю ж змінну предаємо на HTML сторінку
        }

    }
}