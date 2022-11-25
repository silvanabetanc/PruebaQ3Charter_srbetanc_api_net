using BP.API.Entidades;
using BP.Functional;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;

namespace srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi
{
    public interface IConsultarPersonajesRepositorio
    {
        Task<Either<EError, ERespuesta<EPersonajes>>> EjecutarConsultaPersonajes();
    }
}
