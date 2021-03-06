using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Next.Steps.Application.Utils;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using Next.Steps.Domain.Services;
using Next.Steps.Repository.ADO;
using Next.Steps.Repository.Context;
using Next.Steps.Repository.EF.Repository;
using Next.Steps.Repository.Fake;
using System;
using System.IO;
using System.Reflection;

namespace Next.Steps.API
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

            var connection = Configuration["ConnectionString"];
            services.AddDbContext<NextStepsContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IPersonService), typeof(PersonService));

            //Entity Framework
            //services.AddScoped(typeof(IPersonRepository), typeof(PersonRepository));

            //ADO
            services.AddScoped(typeof(IPersonRepository), typeof(PersonRepositoryADO));

            //Fake
            //services.AddSingleton(typeof(IPersonRepository), typeof(FakeRepo));

            services.AddMvc();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            var assembly = AppDomain.CurrentDomain.Load("Next.Steps.Application");
            services.AddMediatR(assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NextSteps Project", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NextSteps Project");
            });

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