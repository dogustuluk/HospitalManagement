using HospitalManagement.API.Extensions.StartupExtensions;
using HospitalManagement.Application;
using HospitalManagement.Infrastructure;
using HospitalManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();
builder.Services.HttpLoggingOptionsStartupExtension();
builder.Services.JsonOptionsStartupExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerOptionsExtension();
builder.Services.JwtOptionsStartupExtension(builder.Configuration);

var app = builder.Build();
//for jquery
app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
app.Services.InitializeSeedData();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();