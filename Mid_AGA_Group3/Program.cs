using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mid_AGA_Group3.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Mid_AGA_Group3ContextConnection") ?? throw new InvalidOperationException("Connection string 'Mid_AGA_Group3ContextConnection' not found.");

builder.Services.AddDbContext<Mid_AGA_Group3Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Mid_AGA_Group3Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
