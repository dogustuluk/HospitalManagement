using Microsoft.OpenApi.Models;

namespace HospitalManagement.API.Extensions.StartupExtensions
{
    public static class SwaggerStartupExtension
    {
        public static void SwaggerOptionsExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(swaggerOpt =>
            {
                swaggerOpt.SwaggerDoc("medSis_V1", new OpenApiInfo
                {
                    Title = "MedSis V1",
                    Description = "MedSis V1 Docs",
                    Version = "Version_1"
                });
                swaggerOpt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token"
                });
                swaggerOpt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        },
                    new string[] {}
                    }
                });
            });
        }
    }
}
