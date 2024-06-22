using Hospital.Core.Identity;
using Hospital.Core.Interfaces;
using Hospital.Infrastructure.Data;
using Hospital.Infrastructure.Repos;
using Hospital.Web.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {

            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(MyMapper));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        
        }
    }
}
