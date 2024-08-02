using HospitalManagement.Client.Extensions.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.JsonOptionsStartupExtension();
builder.Services.AddHttpContextAccessor();
builder.Services.AuthOptionsStartupExtension();
builder.Services.IISOptionsStartupExtension();
builder.Services.HttpClientOptionsStartupExtension(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();