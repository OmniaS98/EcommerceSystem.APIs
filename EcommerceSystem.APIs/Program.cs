using EcommerceSystem.APIs;
using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Data.Context;
using EcommerceSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBLServices();
builder.Services.AddDALServices(builder.Configuration);

// Configure Identity services
builder.Services.AddIdentityCore<Customer>()
    .AddEntityFrameworkStores<EcommerceContext>();


// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
})
    .AddJwtBearer("Default", options =>
    {
        var keyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey);
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig!);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };

    });

var app = builder.Build();

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
