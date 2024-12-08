using System.Text.Json;
using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Generic;
using ActividadUT2.Domain.Persistence;
using ActividadUT2.Domain.Repository;
using ActividadUT2.Domain.Service;
using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    $"appsettings.{builder.Environment.EnvironmentName}.json",
    optional: true
);

IServiceCollection services = builder.Services;

services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DWES"));
    opt.UseLazyLoadingProxies(false);
});

services.AddRouting(options => options.LowercaseUrls = true);

services
    .AddControllers()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
    
services.AddAuthorization();

services.AddSwaggerGen(swg =>
{
    swg.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

services.AddMvc();

services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowAnyOrigin",
        builder =>
            builder
                .WithOrigins("http://localhost")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
    );
});

services.AddResponseCompression();

services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

//Inyeccion de dependencias
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IMapper, Mapper>();
services.AddScoped<DbContext, DatabaseContext>();
services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
services.AddScoped<IEntityRepository<Guid, Cat>, CatRepository>();
services.AddScoped<IEntityService<Guid, CatDTO>, CatService>();

WebApplication webApp = builder.Build();

webApp.UseResponseCompression();

webApp.UseHttpsRedirection();

webApp.UseRouting();

webApp.UseCors("AllowAnyOrigin");

webApp.MapControllers();

webApp.UseSwagger();
webApp.UseSwaggerUI();

webApp.Run();