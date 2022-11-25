using BP.API.Entidades;
using BP.Functional;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;

namespace srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi
{
    public interface IConsultarPersonajesInfraestructura
    {
        Task<Either<EError, ERespuesta<EPersonajes>>> ConsultarPersonajes();
    }
}
