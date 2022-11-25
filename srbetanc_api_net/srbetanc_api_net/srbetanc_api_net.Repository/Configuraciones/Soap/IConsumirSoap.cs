using ServiceReference1;

namespace srbetanc_api_net.Repository.Configuraciones.Soap
{
    public interface IConsumirSoap
    {
        Task<ConsulatECTCResponse> ConsultaEstadosDeCuentaTCAsync(ConsulatECTCRequest servicioInput, ConsultaECTCServiceClient cliente);
        Task<ECDocTCResponse> ConsultaDocEstadoDeCuentaTCAsync(ECDocTCRequest servicioInput, ConsultaECTCServiceClient cliente);
    }
}
