using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ProConfitec.Application.Mappings;
using ProConfitec.Application.Services;
using ProConfitec.Application.Services.Interfaces;
using ProConfitec.Domain.Interfaces;
using ProConfitec.Infra.Contexts;
using ProConfitec.Infra.Respositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Infra
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PPContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Resources/Uploads")));

            return services;



        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(EntityToDtoMapping));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchoolRecordRepository, SchoolRecordRepository>();
            services.AddScoped<IScholarityRepository, ScholarityRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IScholarityService, ScholarityService>();
            return services;
        }
    }
}
