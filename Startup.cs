using Calculator.API.Calculators;
using Calculator.API.Controllers;
using Calculator.API.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Calculator.API
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
            services.AddControllers();

            services.AddTransient<ICalculation, Addition>();
            services.AddTransient<ICalculation, Substraction>();
            services.AddTransient<ICalculation, Multiplication>();
            services.AddTransient<ICalculation, Division>();
            services.AddTransient<CalculatorManager>();
            services.AddTransient<CalculatorManagerWithColor>();

            services.AddTransient(sp => sp.GetServices<ICalculation>().ToDictionary(p => p.OperationType));

            services.AddTransient(sp =>
            {
                return new Func<string, CalculatorManager>((s) => {
                    switch (s)
                    {
                        case "number":
                            return sp.GetService<CalculatorManager>();
                        case "numberWithColor":
                            return sp.GetService<CalculatorManagerWithColor>();
                        default:
                            return null;
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
