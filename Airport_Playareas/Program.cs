using Airport_Playareas;
using MySql.Data.MySqlClient;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("airportplayareas"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IAirportRepository, AirportRepository>();
builder.Services.AddTransient<ILactationAreaRepository, LactationAreaRepository>();
builder.Services.AddTransient<IPlayAreaRepository, PlayAreaRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
var app = builder.Build();

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
    name: "airportview",
    pattern: "Airport/AirportView/{airportId}",
    defaults: new { controller = "Airport", action = "AirportView" });
app.MapControllerRoute(
    name: "airport",
    pattern: "Airport/{action}/{id}",
    defaults: new { controller = "Airport" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
