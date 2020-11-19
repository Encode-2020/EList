using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EList.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace EList
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

            services.AddDbContext<EListContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EListConnection")));
            //services.AddControllers().AddNewtonsoftJson(s =>
            //{
            //    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //});

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IListRepository, EFUserRepository>();
            services.AddScoped<IListReposiroty, EFListRepository>();
            services.AddScoped<IItemRepository, EFItemRepository>();
            services.AddControllers();
            //ADDED AFTER TUTORIAL
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EList API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //ADDED AFTER TUTORIAL
            app.UseSwagger();

            //ADDED AFTER TUTORIAL
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commander API V1");
            });

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
