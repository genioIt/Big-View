using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiEcommerce.Application.App;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Mapper;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Infrastructure.Persistence;
using WebApiEcommerce.Infrastructure.Repository;
using WebApiEcommerce.Infrastructure.Security;
using WebApiECommerce.Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enabled CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<IUserApplication, UserApplication>();
    builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrdersApplication, OrdersApplication>();
    builder.Services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
    builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
    builder.Services.AddScoped<IUserSessionsRepository, UserSessionsRepository>();
    builder.Services.AddScoped<ICartItemsRepository, CartItemsRepository>();
    builder.Services.AddScoped<IJwtProvider, JwtProvider>();
    builder.Services.AddScoped<IAuthApplication, AuthApplication>();
    builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
    builder.Services.AddScoped<IProductCategoriesApplication, ProductCategoriesApplication>();
    builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
    builder.Services.AddScoped<IProductApplication, ProductApplication>();
    builder.Services.AddScoped<ICartApplication, CartApplication>();



}

void ConfigureMapper(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(
          typeof(UsersMapper),
          typeof(ProductCategoriesMapper),
          typeof(ProductMapper),
          typeof(CartItemsMapper),
          typeof(OrdersMapper)
        //typeof(ResponseServiceMapper)
        );
}

//Context
builder.Services.AddDbContext<ECommerceBDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Authentication JWT

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["JwtSettings:Issuer"],
            ValidAudience = config["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]!))
        };
    });

builder.Services.AddAuthorization();

ConfigureServices(builder);
ConfigureMapper(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa la política de CORS
app.UseCors("allowAngular");
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

