using ASP_NET_CORE_SHOP.DATA.Interfaces;//Щоб обєднувати інтерфейси через services.AddTransient не забути прописати
using ASP_NET_CORE_SHOP.DATA.Moks;//Також не забути прописати для зєднання з класом який буде наслібуватись від інтерфейсу      services.AddTransient<IOllCars,MockCars>   and  services.AddTransient<ICarsCategory, MockCategory>
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP
{
    public class Startup
    {
        // Этот метод вызывается средой выполнения. Используйте этот метод для добавления сервисов в контейнер.
        // Для получения дополнительной информации о том, как настроить ваше приложение, посетите https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//Функція для реєстрації модулей, плагінів в середині проекту
        {


            services.AddTransient<IOllCars,MockCars>();//Дозволяє обєднувати між собою інтерфейс IOllCars і клас який реалізовує цей інтрефейс MockCars
            services.AddTransient<ICarsCategory, MockCategory>();//Дозволяє обєднувати між собою інтерфейс ICarsCategory і клас який реалізовує цей інтрефейс MockCategory
             

            services.AddMvc();//Добавили підтримку скачаного раніше плагіну Mvc     (для роботи з контролерами, моделями)


        }

        // Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//Показувати помилкі на сторінках браузеру
            app.UseStatusCodePages();//Показувати коди сторінок(404,200,...)
            app.UseStaticFiles();//Дає можливість відображати різного роду CSS файли, зображення....
            //app.UseMvcWithDefaultRoute();// Дає можливість контроля УРЛ адресів то будуть використовуватись УРЛ за замовчуванням(файл буде в контроллері Home(index.HTML))

        }

        
    }
}
