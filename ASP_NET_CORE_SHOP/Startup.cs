using ASP_NET_CORE_SHOP.DATA.Interfaces;//��� ��������� ���������� ����� services.AddTransient �� ������ ���������
using ASP_NET_CORE_SHOP.DATA.Moks;//����� �� ������ ��������� ��� ������� � ������ ���� ���� ������������ �� ����������      services.AddTransient<IOllCars,MockCars>   and  services.AddTransient<ICarsCategory, MockCategory>
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
        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ���������� �������� � ���������.
        // ��� ��������� �������������� ���������� � ���, ��� ��������� ���� ����������, �������� https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//������� ��� ��������� �������, ������ � ������� �������
        {


            services.AddTransient<IOllCars,MockCars>();//�������� ��������� �� ����� ��������� IOllCars � ���� ���� �������� ��� ��������� MockCars
            services.AddTransient<ICarsCategory, MockCategory>();//�������� ��������� �� ����� ��������� ICarsCategory � ���� ���� �������� ��� ��������� MockCategory
             

            services.AddMvc();//�������� �������� ��������� ����� ������ Mvc     (��� ������ � ������������, ��������)


        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();//���������� ������ �� �������� ��������
            app.UseStatusCodePages();//���������� ���� �������(404,200,...)
            app.UseStaticFiles();//�� ��������� ���������� ������ ���� CSS �����, ����������....
            //app.UseMvcWithDefaultRoute();// �� ��������� �������� ��� ������ �� ������ ����������������� ��� �� �������������(���� ���� � ���������� Home(index.HTML))

        }

        
    }
}
