using BP.API.Constantes;
using BP.API.Entidades.Excepciones;
using BP.API.Entidades.Extensiones;
using BP.API.Entidades;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using Microsoft.AspNetCore.Mvc;
using srbetanc_api_net.Entity;
using System.Net;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;

namespace srbetanc_api_net.API.Controllers
{
    [ApiVersion("1")]
    [Route(Controlador.RutaVersion)]
    [ApiController]
    public class ConsultarPersonajesController: ControllerBase
    {
        private readonly IConsultarPersonajesInfraestructura iConsultarPersonajesInfraestructura;

        public ConsultarPersonajesController(IConsultarPersonajesInfraestructura iConsultarPersonajesInfraestructura)
        {
            this.iConsultarPersonajesInfraestructura = iConsultarPersonajesInfraestructura;
        }

        [HttpGet]
        [Route(EConstantes.Recurso002)]
        [Loggable]
        public async Task<IActionResult> ConsultarPersonajes02()
        {
            EError error = new EError(this.GetFirstName(), EConstantes.Recurso002, "api");
            ERespuesta<EPersonajes> salida = new ERespuesta<EPersonajes>(new EHeader(), new EPersonajes(), error);
            try
            {
                return (await iConsultarPersonajesInfraestructura.ConsultarPersonajes()).Match(
                   Left => StatusCode(HttpStatusCode.BadRequest.ToInt(), salida.AgregarError(Left)),
                   Right => Ok(Right));
            }
            catch (CoreNegocioError negocioError)
            {
                negocioError.ProcesarError(salida);
                return StatusCode(HttpStatusCode.BadRequest.ToInt(), salida);
            }
            catch (Exception excepcion)
            {
                excepcion.ProcesarError(salida);
            }
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), salida);
        }
    }
}
