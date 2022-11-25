using BP.API.Entidades;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.Functional;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;

namespace srbetanc_api_net.Infrastructure.Services.rickandmortyapi
{
    public class ConsultarPersonajesInfraestructura : IConsultarPersonajesInfraestructura
    {
        private readonly IConsultarPersonajesRepositorio iConsultarPersonajesRepositorio;

        public ConsultarPersonajesInfraestructura(IConsultarPersonajesRepositorio iConsultarPersonajesRepositorio)
        {
            this.iConsultarPersonajesRepositorio = iConsultarPersonajesRepositorio;
        }

        [Loggable]
        public async Task<Either<EError, ERespuesta<EPersonajes>>> ConsultarPersonajes()
        {
            var procesoExitosa = true;
            ERespuesta<EPersonajes> consultaResponse = new();

            EError error = new(this.GetFirstName(), "0002", "api") { };

            (await iConsultarPersonajesRepositorio.EjecutarConsultaPersonajes()).Match(
            Right: x =>
            {
                if (x.Error.Codigo.IsNullEmpty())
                {
                    error = new(this.GetFirstName(), "0002", "api")
                    {
                        Tipo = "error",
                        Codigo = "8888",
                        Mensaje = "errror api",
                    };
                    procesoExitosa = false;
                }
                else if (!x.Error.Codigo.Equals("0"))
                {
                    error = new EError(this.GetFirstName(), "0002", "api")
                    {
                        Tipo = "error",
                        Codigo = "6666",
                        Mensaje = "api",
                    };
                    procesoExitosa = false;
                }
                else
                {
                    consultaResponse = x;
                }
            },
            Left: x =>
            {
                error = x;
                procesoExitosa = false;
            });
            if (!procesoExitosa) return error;
            else return consultaResponse;
        }
    }
}
