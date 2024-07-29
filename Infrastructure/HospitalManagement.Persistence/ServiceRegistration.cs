using HospitalManagement.Application.Extensions;
using HospitalManagement.Application.Repositories.Appointment;
using HospitalManagement.Domain;
using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Persistence.Context;
using HospitalManagement.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            

            services.RegisterRepositories(typeof(IAppointmentReadRepository).Assembly, typeof(ErrorReadRepository).Assembly);
            services.AddServicesInDbContextFromAttributes(Assembly.GetExecutingAssembly());
        }

        public static void InitializeSeedData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HospitalManagementDbContext>();
                SeedDataHelper.SeedDepartments(dbContext);
            }
        }

    }
}
