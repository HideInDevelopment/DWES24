using System.Text.Json;
using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Entities;
using API_Gatinos.Models.Repositories.GenericDBConnection;
using API_Gatinos.Models.Repositories.Implementations;
using API_Gatinos.Models.Repositories.Interfaces;
using API_Gatinos.Models.Services.Implementations;
using API_Gatinos.Models.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    $"appsettings.{builder.Environment.EnvironmentName}.json",
    optional: true
);

IServiceCollection services = builder.Services;

//Descomentar cuando se configure la base de datos
//services.AddDbContext<DatabaseContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("DWES2024"));
//    opt.UseLazyLoadingProxies(false);
//});

services.AddRouting(options => options.LowercaseUrls = true);

services
    .AddControllers()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

//Aniadir autenticacion y autorizacion por JWT en el futuro

services.AddAuthorization();

services.AddSwaggerGen(swg =>
{
    swg.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    //Descomentar cuando este implementada la autenticacion y autorizacion
    //swg.AddSecurityDefinition(
    //    "Bearer",
    //    new OpenApiSecurityScheme
    //    {
    //        Description =
    //            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    //        Name = "Authorization",
    //        In = ParameterLocation.Header,
    //        Type = SecuritySchemeType.Http,
    //        Scheme = "bearer"
    //    }
    //);

    //swg.AddSecurityRequirement(
    //    new OpenApiSecurityRequirement()
    //    {
    //        {
    //            new OpenApiSecurityScheme
    //            {
    //                Reference = new OpenApiReference
    //                {
    //                    Type = ReferenceType.SecurityScheme,
    //                    Id = "Bearer"
    //                },
    //                Scheme = "oauth2",
    //                Name = "Bearer",
    //                In = ParameterLocation.Header,
    //            },
    //            new List<string>()
    //        }
    //    }
    //);
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
services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
services.AddScoped<IEntityRepository<Guid, Colaborador>, ColaboradorRepository>();
services.AddScoped<IEntityRepository<Guid, Gato>, GatoRepository>();
services.AddScoped<IEntityRepository<Guid, Colonia>, ColoniaRepository>();
services.AddScoped<IEntityService<Guid, ColoniaDTO>, ColoniaService>();
services.AddScoped<IEntityService<Guid, GatoDTO>, GatoService>();
services.AddScoped<IEntityService<Guid, ColaboradorDTO>, ColaboradorService>();

WebApplication webApp = builder.Build();

webApp.UseResponseCompression();

webApp.UseHttpsRedirection();

webApp.UseRouting();

//webApp.UseAuthentication();

//webApp.UseAuthorization();

webApp.UseCors("AllowAnyOrigin");

webApp.MapControllers() /*.RequireAuthorization()*/
;

webApp.UseSwagger();
webApp.UseSwaggerUI();

webApp.Run();
