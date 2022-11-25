using BP.API.Entidades;
using BP.Functional;
using srbetanc_api_net.Entity.Services.ServiceName.Entrada;
using srbetanc_api_net.Entity.Services.ServiceName.Salida;

namespace srbetanc_api_net.Domain.Interfaces.Services.ServiceName
{
    public interface IServiceNameInfraestructura
    {
        Task<Either<EError, ERespuesta<ETarjetas>>> ConsultarTarjetas(EEntrada<EProveedor> entrada);
    }
}