using ASP_NET_CORE_SHOP.DATA;
using ASP_NET_CORE_SHOP.DATA.Interfaces;//Щоб обєднувати інтерфейси через services.AddTransient не забути прописати
using ASP_NET_CORE_SHOP.DATA.Models;
using ASP_NET_CORE_SHOP.DATA.Moks;//Також не забути прописати для зєднання з класом який буде наслібуватись від інтерфейсу      services.AddTransient<IOllCars,MockCars>   and  services.AddTransient<ICarsCategory, MockCategory>
using ASP_NET_CORE_SHOP.DATA.Repository;
using Microsoft.AspNetCore.Builder;//!
using Microsoft.AspNetCore.Hosting;//!
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;//IConfigurationRoot       //!
using Microsoft.Extensions.DependencyInjection;//!


namespace ASP_NET_CORE_SHOP
{//ПРОГРАМА БУДЕ ПОЧИНАТИСЬ з класус Program, але оскільки там прописаний цей клас як UseStartup<Startup> то в цьому класі будемо прописувати всі основні інклуди(будь то БД, Мок, Транзіти....
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv) //Конструктор для отримання рядка з файла dbSettings.json
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();//SetBasePath-початковий путь до папки, в цій папці кажемо добав файл dbSettings.json через команду  AddJsonFile і виконай отримання даного файлу Build
        }

        // Этот метод вызывается средой выполнения. Используйте этот метод для добавления сервисов в контейнер.
        // Для получения дополнительной информации о том, как настроить ваше приложение, посетите https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//Функція для реєстрації модулей, плагінів в середині проекту
        {
            services.AddDbContext<AppDBcontent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));//Підключення БД (Устаріло но все ж) UseSqlServer треба окремо підлкючити Microsoft.EntityFrameworkCore.SqlServer витягуємо строку DefaultConnection

            //Прописання який інтерфейс реалізовується в якому класі(БЕЗ БД)
            //services.AddTransient<IAllCars,MockCars>();//Дозволяє обєднувати між собою інтерфейс IOllCars і клас який реалізовує цей інтрефейс MockCars
            //services.AddTransient<ICarsCategory, MockCategory>();//Дозволяє обєднувати між собою інтерфейс ICarsCategory і клас який реалізовує цей інтрефейс MockCategory

            //Прописання який інтерфейс реалізовується в якому класі БД         інтерфейси реалізуються в класах CarRepository і CategoryRepository а ці репозиторії в свою чергу слугують дял роботи з БД
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddControllersWithViews();

            //Для роботи з Корзиною
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));//для двох різних користувачів буде 2 різні корзини

            services.AddMvc();//Добавили підтримку скачаного раніше плагіну Mvc     (для роботи з контролерами, моделями)

            //після додавання сесій і підключення NuGet
            services.AddMemoryCache();//Використовуємо кеш
            services.AddSession();//Використовуємо сесії
        }

        // Этот метод вызывается средой выполнения. Используйте этот метод для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//Показувати помилкі на сторінках браузеру
            app.UseStatusCodePages();//Показувати коди сторінок(404,200,...)
            app.UseStaticFiles();//Дає можливість відображати різного роду CSS файли, зображення....
                                 //app.UseMvcWithDefaultRoute();// Дає можливість контроля УРЛ адресів то будуть використовуватись УРЛ за замовчуванням(файл буде в контроллері Home(index.HTML))
            app.UseSession();//Використовуємо сесії




            app.UseRouting();
            app.UseEndpoints(o =>o.MapControllerRoute("default", "{controller=Cars}/{action=List}/{id?}"));

            //Створюємо первне середовище
            using (var scoupe = app.ApplicationServices.CreateScope())
            {
                AppDBcontent content = scoupe.ServiceProvider.GetRequiredService<AppDBcontent>();//створюємо змінну content в межах середовища scoupe
                DBObjects.Initial(content);//яку перекідаємо в метод Initial який потім буде використовуватись в DBObjects.cs
            }


            //DBObjects.Initial(app);//при старті програми, будемо визивати ініціалізацію БД
        }

        
    }
}
