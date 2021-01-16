using ASP_NET_CORE_SHOP.DATA.Models;//Category
using Microsoft.AspNetCore.Builder;//IApplicationBuilder
using Microsoft.Extensions.DependencyInjection;//GetRequiredService
using System;
using System.Collections.Generic;
using System.Linq;//Select...
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA
{
    public class DBObjects//Всі функції в середині цього класу будуть статичні, для того щоб звертатись до функцій цього класу, по імені самої функції
    {
        public static void Initial(AppDBcontent content)//Ця функція буде прописана в Startup і вона буде кожен раз добавляти обєкти і витягувати з БД при старті програми 
        {
            
                //AppDBcontent content = app.ApplicationServices.GetRequiredService<AppDBcontent>();//Обращаємось до класу AppDBcontent який служить для роботи з БД і підключаємо його і на його основі можемо працювати з БД
        //Добавляємо всі категорії в бд при умові що їх там немає
        if(!content.Category.Any())//якщо ми НЕ отримуємо всіх категорій
            {
                content.Category.AddRange(Categories.Select(z=>z.Value));           //AddRange набір елементів буде вибиратись(Select) із нами створеної функції Categories(нижче)
            }

        if(!content.Car.Any())//якщо немає ніяких обєктів тоді:
            {//можемо прописати як прописували для Категорії---Створити функцію на заповнення у випадку пустоти або ж взяти з раніше створеного файлу MockCars.cs:
                content.AddRange(
                    new Car
                    {
                        name = "Tesla Модел S",
                        shortDesc = "Білий автомобіль Tesla",
                        longDesc = "Швидкий з середнім запасом ходу",
                        img = "/img/Tesla Модел S.jpg",
                        price = 45000,
                        isFavorite = true,
                        avalible = 20,
                        Category = Categories["Електро мобілі"]
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
                        Category = Categories["Електро мобілі"]
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
                        Category = Categories["Дизельні автомобілі"]
                    }
                    );
            }
            content.SaveChanges();//ОБОВЯЗКОВА функція для збереження змін

        }

        private static Dictionary<string, Category> category;//створюємо приватну змінну-словник
        public static Dictionary<string, Category> Categories//Функція буде повертати певний список(Словник Dictionary в який потрібно передати ключі типу string і значення елементів з моделі Category)
        {
            get
            {
                if(category==null)//якщо в вище створеній приватній змінній не має обєктів тоді добавимо їх
                {
                    var list = new Category[]//ствоюємо новий списов в якому будемо прописувати самі категорії які створювали раніше в файлі MockCategory.cs(MOCKS)
                    {
                    new Category{categoryName="Електро мобілі", desc="Приводяться в рух, за допомогою електричного струму" },
                    new Category{categoryName="Бензинові автомобілі", desc="Приводяться в рух, за допомогою бензину" },
                    new Category{categoryName="Дизельні автомобілі", desc="Приводяться в рух, за допомогою Дизельного палива" },
                    new Category{categoryName="Бензини водородного синтезу", desc="Приводяться в рух, за допомогою електролітичних конвекцій з подальшим видобутком водороду" },
                    };
                    category = new Dictionary<string, Category>(); //виділення памяті
                    foreach(Category el in list)//цикл для додавання в середину змінної category всіх елементів ліста(масива)
                    {
                        category.Add(el.categoryName, el);//ключом буде categoryName (імя категорії) а значенням буде сам обєкт який ми передаємо
                    }    
                }
                return category;
            }
        }
    }
}
