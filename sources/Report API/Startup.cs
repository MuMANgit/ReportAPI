using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReportAPP.BLL.Interfaces;
using ReportAPP.BLL.Mapping;
using ReportAPP.BLL.Services;
using ReportAPP.DAL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Report_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EmployeeContext>(options => options.UseNpgsql(connection));

            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));

            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "ReportAPP.WEB.xml"/*, "ReportAPP.BLL.xml"*/);

                var filePath1 = Path.Combine(System.AppContext.BaseDirectory, "ReportAPP.BLL.xml");


                c.IncludeXmlComments(filePath);
                c.IncludeXmlComments(filePath1);

                //c.IncludeXmlComments(string.Format($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\core.XML"));
            });

            services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/reportApp-{Date}.txt");

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Report v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
