using Microsoft.EntityFrameworkCore;
using Task.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();
// Enable CORS
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();




app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.Run();
