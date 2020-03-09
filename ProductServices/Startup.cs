using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProductServices.Application.Interfaces;
using ProductServices.Application.Models.Query;
using ProductServices.Application.UseCases.Product.Command.CreateProduct;
using ProductServices.Application.UseCases.Product.Queries.GetProduct;
using ProductServices.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductServices.Infrastructure.Presistence;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ProductServices
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
            services.AddDbContext<dbContext>(option => option.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=sayangkamu;Database=productservicesdb"));
            services.AddMvc().AddFluentValidation();
            services.AddControllers();

            services
            .AddMediatR(typeof(GetProdcutQueryHandler).GetTypeInfo().Assembly);

            services
            .AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));

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
