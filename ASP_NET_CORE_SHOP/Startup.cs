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
            services.AddMvc();//Добавили підтримку скачаного раніше плагіну Mvc     (для роботи з контролерами, моделями)
        }

        // Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//Якщо ми зараз в режимі IsDevelopment                      є два режима: Розробки і публікації (Девелоп\Продакшен) Міняється в пкм на проекті і свойства
            {
                app.UseDeveloperExceptionPage();//То показуємо пимилкі навіть в браузері                    інакше якщо в іншому режимі, то показуємо просто сторінка 404(не знайдена)
            }
            if(env.IsProduction())//якщо будемо в режимі продакшена
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Production\t");//Виведеться це повядомлення
                });
            }




            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
