using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SolidPractice.Business.Abstract;
using SolidPractice.Business.Concrete;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.DataAccess.CQRS.Abstract;
using SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.CommandHandlers;
using SolidPractice.DataAccess.CQRS.EntityFramework.Handlers.QueryHandlers;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Request.Address;
using SolidPractice.DataAccess.CQRS.EntityFramework.Queries.Response.Address;
using SolidPractice.DataAccess.Dapper;
using SolidPractice.DataAccess.EntityFramework;
using SolidPractices.Entities;
using AddressManager = CQRSBusiness.Concrete.AddressManager;
using IAddressService = CQRSBusiness.Abstract.IAddressService;

namespace SolidPractice.WebAPI
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

            services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    //INCLUDE
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolidPractice.WebAPI", Version = "v1" });
            });

            services.AddScoped<IAddressDal, DapperAddressRepository>();
            services.AddScoped<ICustomerDal, DapperCustomerRepository>();
            services.AddScoped<IEmployeeDal, DapperEmployeeRepository>();
            services.AddScoped<ISupplierDal, DapperSupplierRepository>();


            //CQRS
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IAddressService, AddressManager>();
            //services.AddTransient<IRequestHandler<GetAllAddressesQueryRequest, List<GetAllAddressesQueryResponse>>, GetAllAddressesQueryHandler>();



            //services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ISupplierService, SupplierManager>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SolidPractice.WebAPI v1"));
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
