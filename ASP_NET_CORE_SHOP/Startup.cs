using ASP_NET_CORE_SHOP.DATA.Interfaces;//��� ��������� ���������� ����� services.AddTransient �� ������ ���������
using ASP_NET_CORE_SHOP.DATA.Moks;//����� �� ������ ��������� ��� ������� � ������ ���� ���� ������������ �� ����������      services.AddTransient<IOllCars,MockCars>   and  services.AddTransient<ICarsCategory, MockCategory>
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_NET_CORE_SHOP
{
	public class Startup
    {
        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� �������� � ���������.
        // ��� ��������� �������������� ���������� � ���, ��� ��������� ���� ����������, �������� https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//������� ��� ��������� �������, ������ � ������� �������
        {
            services.AddTransient<IAllCars,MockCars>();//�������� ��������� �� ����� ��������� IOllCars � ���� ���� �������� ��� ��������� MockCars
            services.AddTransient<ICarsCategory, MockCategory>();//�������� ��������� �� ����� ��������� ICarsCategory � ���� ���� �������� ��� ��������� MockCategory

            services.AddControllersWithViews();//�������� �������� ��������� ����� ������ Mvc     (��� ������ � ������������, ��������)
        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//���������� ������ �� �������� ��������
            app.UseStatusCodePages();//���������� ���� �������(404,200,...)
            app.UseStaticFiles();//�� ��������� ���������� ������ ���� CSS �����, ����������....

            app.UseRouting();
            app.UseEndpoints(o =>
                o.MapControllerRoute("default", "{controller=Cars}/{action=List}/{id?}"));
        }        
    }
}
