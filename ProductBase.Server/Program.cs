
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductBase.Data;
using ProductBase.Server.CustomMiddleware;
using ProductBase.Server.Repositories;
using Serilog;
using Serilog.Formatting.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var logDirectory = "F:\\subhamPractice.net";
if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}
builder.Host.UseSerilog((context, config) => {
    config
        .MinimumLevel.Information()
        .WriteTo.Console(new JsonFormatter()) // Log in JSON format to the console
        .WriteTo.File(new JsonFormatter(), Path.Combine(logDirectory, "log-.json"), rollingInterval: RollingInterval.Day); // Log in JSON format to files
});
builder.Services.AddDbContext<ProdectDetailesDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnString")));
builder.Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
builder.Services.AddTransient<IProductTypeRepo, ProductTypeRepo>();
builder.Services.AddTransient<IProductDetailsRepo, ProductDetailsRepo>();
builder.Services.AddTransient<ILoginRepo, LoginsRepo>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("https://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
       // ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});
// other service configurations like AddControllers, etc.
var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingmiddleware> ();
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
try
{
    Log.Information("Starting up the application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
