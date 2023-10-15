using ETicaretAPI.Application.Absractions.Services;
using ETicaretAPI.Application.Absractions.Services.Authentications;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repository;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using ETicaretAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

           
            //Indetity kontrol mekanizmamız projemize ekleniyor.
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;    
                options.Password.RequireDigit= false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase= false;
                
            }).AddEntityFrameworkStores<ETicaretAPIDbContext>();
           
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImagesFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImagesFileWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
            services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();

            services.AddScoped<IUserService, UserService>();


        }
    }
}
