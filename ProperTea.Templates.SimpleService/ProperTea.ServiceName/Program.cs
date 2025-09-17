using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ProperTea.ProperCqrs;
using ProperTea.ServiceDefaults;
using ProperTea.ServiceName.Configuration;
using ProperTea.ServiceName.Endpoints;
using ProperTea.ServiceName.Persistence;
using ProperTea.Shared.Api.ErrorHandling;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Authentication:Authority"];
        options.Audience = builder.Configuration["Authentication:Audience"];
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    });
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddGlobalErrorHandling("ProperTea.ServiceName");

builder.Services.AddProperCqrs();

builder.Services.AddServices();

builder.Services.AddDbContext<ServiceNameDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("service-name-db");
    options.UseSqlServer(connection);
});
builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ServiceNameDbContext>());

var app = builder.Build();

app.UseGlobalErrorHandling("ProperTea.ServiceName");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapServiceNameEndpoints();

app.MapDefaultEndpoints();

app.Run();