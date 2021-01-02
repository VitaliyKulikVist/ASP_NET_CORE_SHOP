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
            services.AddMvc();//�������� �������� ��������� ����� ������ Mvc     (��� ������ � ������������, ��������)
        }

        // ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//���� �� ����� � ����� IsDevelopment                      � ��� ������: �������� � ��������� (�������\���������) ̳������� � ��� �� ������ � ��������
            {
                app.UseDeveloperExceptionPage();//�� �������� ������ ����� � �������                    ������ ���� � ������ �����, �� �������� ������ ������� 404(�� ��������)
            }
            if(env.IsProduction())//���� ������ � ����� ����������
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Production\t");//���������� �� ������������
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
