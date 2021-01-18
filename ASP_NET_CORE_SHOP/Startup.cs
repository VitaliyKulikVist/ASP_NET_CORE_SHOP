using ASP_NET_CORE_SHOP.DATA;
using ASP_NET_CORE_SHOP.DATA.Interfaces;//��� ��������� ���������� ����� services.AddTransient �� ������ ���������
using ASP_NET_CORE_SHOP.DATA.Models;
using ASP_NET_CORE_SHOP.DATA.Moks;//����� �� ������ ��������� ��� ������� � ������ ���� ���� ������������ �� ����������      services.AddTransient<IOllCars,MockCars>   and  services.AddTransient<ICarsCategory, MockCategory>
using ASP_NET_CORE_SHOP.DATA.Repository;
using Microsoft.AspNetCore.Builder;//!
using Microsoft.AspNetCore.Hosting;//!
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;//IConfigurationRoot       //!
using Microsoft.Extensions.DependencyInjection;//!


namespace ASP_NET_CORE_SHOP
{//�������� ���� ���������� � ������ Program, ��� ������� ��� ���������� ��� ���� �� UseStartup<Startup> �� � ����� ���� ������ ����������� �� ������ �������(���� �� ��, ���, �������....
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv) //����������� ��� ��������� ����� � ����� dbSettings.json
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();//SetBasePath-���������� ���� �� �����, � ��� ����� ������ ����� ���� dbSettings.json ����� �������  AddJsonFile � ������� ��������� ������ ����� Build
        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� �������� � ���������.
        // ��� ��������� �������������� ���������� � ���, ��� ��������� ���� ����������, �������� https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//������� ��� ��������� �������, ������ � ������� �������
        {
            services.AddDbContext<AppDBcontent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));//ϳ��������� �� (������� �� ��� �) UseSqlServer ����� ������ ��������� Microsoft.EntityFrameworkCore.SqlServer �������� ������ DefaultConnection

            //���������� ���� ��������� ������������ � ����� ����(��� ��)
            //services.AddTransient<IAllCars,MockCars>();//�������� ��������� �� ����� ��������� IOllCars � ���� ���� �������� ��� ��������� MockCars
            //services.AddTransient<ICarsCategory, MockCategory>();//�������� ��������� �� ����� ��������� ICarsCategory � ���� ���� �������� ��� ��������� MockCategory

            //���������� ���� ��������� ������������ � ����� ���� ��         ���������� ����������� � ������ CarRepository � CategoryRepository � �� ��������� � ���� ����� �������� ��� ������ � ��
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddControllersWithViews();

            //��� ������ � ��������
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));//��� ���� ����� ������������ ���� 2 ��� �������

            services.AddMvc();//�������� �������� ��������� ����� ������ Mvc     (��� ������ � ������������, ��������)

            //���� ��������� ���� � ���������� NuGet
            services.AddMemoryCache();//������������� ���
            services.AddSession();//������������� ���
        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//���������� ������ �� �������� ��������
            app.UseStatusCodePages();//���������� ���� �������(404,200,...)
            app.UseStaticFiles();//�� ��������� ���������� ������ ���� CSS �����, ����������....
                                 //app.UseMvcWithDefaultRoute();// �� ��������� �������� ��� ������ �� ������ ����������������� ��� �� �������������(���� ���� � ���������� Home(index.HTML))
            app.UseSession();//������������� ���




            app.UseRouting();
            app.UseEndpoints(o =>o.MapControllerRoute("default", "{controller=Cars}/{action=List}/{id?}"));

            //��������� ������ ����������
            using (var scoupe = app.ApplicationServices.CreateScope())
            {
                AppDBcontent content = scoupe.ServiceProvider.GetRequiredService<AppDBcontent>();//��������� ����� content � ����� ���������� scoupe
                DBObjects.Initial(content);//��� ��������� � ����� Initial ���� ���� ���� ����������������� � DBObjects.cs
            }


            //DBObjects.Initial(app);//��� ����� ��������, ������ �������� ����������� ��
        }

        
    }
}
