using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MerchantServices.Application.Interfaces;
using MerchantServices.Application.Models.Query;

using MerchantServices.Application.UseCases.Merchant.Command.CreateMerchant;
using MerchantServices.Application.UseCases.Merchant.Queries.GetMerchant;

using MerchantServices.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MerchantServices.Infrastructure.Presistences;

namespace MerchantServices
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
            services.AddDbContext<dbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));
            services.AddMvc().AddFluentValidation();

             services
            .AddMediatR(typeof(GetMerchantQueryHandler).GetTypeInfo().Assembly);
           
            services.AddControllers();

            services
            .AddTransient<IValidator<CreateMerchantCommand>, CreateMerchantCommandValidator>();

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
