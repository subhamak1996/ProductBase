using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductBase.Data;
using ProductBase.Server.CustomMiddleware;
using ProductBase.Server.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProdectDetailesDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnString")));
builder.Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
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
        //ValidateLifetime = true,
       // ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
//});
//builder.Services.AddCors(options =>
//{
//    //options.AddPolicy("AllowAll", builder =>
//    //{
//    //    builder.AllowAnyOrigin()    
//    //           .AllowAnyMethod()    
//    //           .AllowAnyHeader();  
//    //});

//    // You can create specific policies if needed for different requirements
//    options.AddPolicy("CorsAllow", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")  // Replace with your front-end domain
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });

//});

// other service configurations like AddControllers, etc.
var app = builder.Build();

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
