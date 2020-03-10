using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomerServices.Application.Interfaces;
using CustomerServices.Application.Models.Query;
using CustomerServices.Application.UseCases.Customer.Command.CreateCustomer;
using CustomerServices.Application.UseCases.Customer.Queries.GetCustomer;
using CustomerServices.Application.UseCases.Payment.Command.CreatePayment;
using CustomerServices.Application.UseCases.Payment.Queries.GetPayment;

using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CustomerServices.Infrastructure.Presistences;
namespace CustomerServices
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
            services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly)
            .AddMediatR(typeof(GetPaymentQueryHandler).GetTypeInfo().Assembly);


            services.AddControllers();


            services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>()
                .AddTransient<IValidator<CreatePaymentCommand>, CreatePaymentCommandValidator>();

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
