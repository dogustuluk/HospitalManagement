using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HospitalManagementDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //for test mode
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<HospitalManagementDbContext>();//identity
        }
    }
}
