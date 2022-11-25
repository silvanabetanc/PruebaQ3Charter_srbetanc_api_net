using BP.API.Entidades;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.Functional;
using Newtonsoft.Json;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Entity;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;

namespace srbetanc_api_net.Repository.Services.rickandmortyapi
{
    public class ConsultarPersonajesRepositorio : IConsultarPersonajesRepositorio
    {
        [Loggable]
        public async Task<Either<EError, ERespuesta<EPersonajes>>> EjecutarConsultaPersonajes()
        {
            var httpCliente = new HttpClient();
            ERespuesta<EPersonajes> respuestaConsulta = new();
            httpCliente.BaseAddress = new Uri(EConstantes.UrlRickAndMorty);
            var respuestaApi = await httpCliente.GetAsync(EConstantes.UrlRickAndMorty);

            if (respuestaApi.IsSuccessStatusCode)
            {
                var jsonRespuestaApi = await respuestaApi.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<EPersonajes>(jsonRespuestaApi);
                respuestaConsulta.HeaderOut = new EHeader();
                respuestaConsulta.BodyOut = resultado!;
                respuestaConsulta.Error = new(this.GetFirstName(), EConstantes.Recurso002, "Api") { };
            }
            else
            {
                return new EError(this.GetFirstName(), "002", "api")
                {
                    Tipo = "error",
                    Codigo = "999",
                    Mensaje = "Error al invocar api : ",
                };
            }
            return respuestaConsulta;
        }
    }
}
