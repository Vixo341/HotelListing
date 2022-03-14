using HotelListing.Data;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HotelListing.Configurations;
using HotelListing.IRepository;
using HotelListing.Repository;
using Microsoft.AspNetCore.Identity;
using HotelListing;
using HotelListing.Services;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
}); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddResponseCaching();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddAutoMapper(typeof(MapperInitilizer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File(path: "c:\\hotellistings\\logs\\log-.txt",
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{level:u3}] {Message:lj}{NewLine}{Exception}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    );
builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120

    });
}).AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.ConfigureVersioning();

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseSwagger();
        app.UseSwaggerUI(c =>
    {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Hotel Listing API");
    });
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    }

    app.ConfigureExceptionHandler();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseIpRateLimiting();
    app.UseResponseCaching();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
app.MapRazorPages();
    app.UseCors("CorsPolicy");
    app.Run();

