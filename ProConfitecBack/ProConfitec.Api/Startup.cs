using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProConfitec.Application.Mappings;
using ProConfitec.Application.Services;
using ProConfitec.Application.Services.Interfaces;
using ProConfitec.Domain.Interfaces;
using ProConfitec.Infra;
using ProConfitec.Infra.Contexts;
using ProConfitec.Infra.Respositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProConfitec.Api
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

            services.AddInfraStructure(Configuration);
            services.AddServices(Configuration);

            //services.AddDbContext<PPContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            //services.AddControllers().AddNewtonsoftJson(options =>
            //{
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});

            //services.AddAutoMapper(typeof(EntityToDtoMapping));
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ISchoolRecordRepository, SchoolRecordRepository>();
            //services.AddScoped<IScholarityRepository, ScholarityRepository>();
            //services.AddScoped<IFileRepository, FileRepository>();
            //services.AddScoped<IScholarityService, ScholarityService>();

            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});


            //services.AddSingleton<IFileProvider>(
            //new PhysicalFileProvider(
            //Path.Combine(Directory.GetCurrentDirectory(), "Resources/Uploads")));



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProConfitec.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProConfitec.Api v1"));
            }

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
