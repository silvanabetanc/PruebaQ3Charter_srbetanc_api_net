#region USING

using BP.Comun.Centralizada;
using BP.Comun.Centralizada.Interfaces;
using BP.Comun.Logs;
using Microsoft.OpenApi.Models;
using srbetanc_api_net.API;
using srbetanc_api_net.Domain.Interfaces.Propiedades;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Domain.Interfaces.Services.ServiceName;
using srbetanc_api_net.Infrastructure.Services.rickandmortyapi;
using srbetanc_api_net.Infrastructure.Services.ServiceName;
using srbetanc_api_net.Repository.Configuraciones.Api;
using srbetanc_api_net.Repository.Configuraciones.Centralizada;
using srbetanc_api_net.Repository.Configuraciones.Soap;
using srbetanc_api_net.Repository.Services.rickandmortyapi;
using srbetanc_api_net.Repository.Services.ServiceName;

#endregion

#region MAIN API

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region REPOSITORIOS
builder.Services.AddSingleton<IConsultarPersonajesRepositorio, ConsultarPersonajesRepositorio>();
builder.Services.AddSingleton<IServiceNameRepositorio, ConsultaTarjetaRepositorio>();

#endregion REPOSITORIOS

#region INFRAESTRUCTURA
builder.Services.AddSingleton<IConsultarPersonajesInfraestructura, ConsultarPersonajesInfraestructura>();
builder.Services.AddSingleton<IServiceNameRepositorio, ConsultaTarjetaRepositorio>();

#endregion INFRAESTRUCTURA

#region SOAP
builder.Services.AddSingleton<IConsumirSoap, ConsumirSoap>();
#endregion INFRAESTRUCTURA

#region CONFIGURADORES CENTRALIZADA

builder.Services.AddSingleton<IPropiedadesApi, PropiedadesApi>();
builder.Services.AddSingleton<IConfiguradorCentralizada, ConfiguradorCentralizada>();
builder.Services.AddSingleton<IConfiguracionCentralizada, ConfiguracionCentralizada>();

#endregion

#region POLITICA PARA DOMINIO CRUZADO 

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                   .AllowAnyMethod()
                                                   .AllowAnyHeader()));
#endregion POLITICA PARA DOMINIO CRUZADO

#region SWAGGER HEADER

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.1.0",
        Title = "srbetanc_api_net",
        Description = "Servicio base para invocar servicios externos",
        Contact = new OpenApiContact
        {
            Name = "Banco Pichincha",
            Email = "devops@pichincha.com",
            Url = new Uri("https://www.pichincha.com"),
        }
    });

});

#endregion SWAGGER

#region MANEJO DE VERSIONES DE API

builder.Services.AddApiVersioning(options => options.UseApiBehavior = true);
builder.Services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);

#endregion MANEJO DE VERSIONES DE API FIN

#region INICIALIZAR CENTRALIZADA
try
{
    builder.Services.AddHostedService<InitConfig>();
}
catch (Exception)
{
}
#endregion INICIALIZAR CENTRALIZADA

#region INICIALIZAR COMPONENTE DE LOGS
builder.Services.AddLogs();
#endregion INICIALIZAR COMPONENTE DE LOGS


var app = builder.Build();


if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");

#region SWAGGER DOCUMENT

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WSClientes0220 API V1");
});
#endregion Swagger

app.MapControllers();
app.Run();

