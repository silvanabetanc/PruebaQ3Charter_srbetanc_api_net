using BP.API.Entidades;
using BP.Functional;
using Moq;
using NUnit.Framework;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Entity.Services.rickandmortyapi.Salida;
using srbetanc_api_net.Infrastructure.Services.rickandmortyapi;

namespace srbetanc_api_net.Test.InfraestructuraTest.Services.rickandmortyapi
{
    public class ConsultarPersonajesTest
    {

        private Mock<IConsultarPersonajesRepositorio> iConsultarPersonajesRepositorio;
        private IConsultarPersonajesInfraestructura iConsultarPersonajesInfraestructura;

        [SetUp]
        public void Setup()
        {
            iConsultarPersonajesRepositorio = new Mock<IConsultarPersonajesRepositorio>();
            iConsultarPersonajesInfraestructura = new ConsultarPersonajesInfraestructura(iConsultarPersonajesRepositorio.Object);
            iConsultarPersonajesRepositorio.Setup(r => r.EjecutarConsultaPersonajes()).ReturnsAsync(resultadoOK);
            iConsultarPersonajesRepositorio.Verify();
        }


        [Test]
        public void ConsultarPersonajes_ReturnsPersonajes()
        {
            var respuesta = iConsultarPersonajesInfraestructura.ConsultarPersonajes();
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }

        private static Either<EError, ERespuesta<EPersonajes>> resultadoOK()
        {
            ERespuesta<EPersonajes> consultaResponse = new()
            {
                Error = new()
                {
                    Codigo = "0",
                    Mensaje = "OK",
                    Tipo = "INFO",
                    Recurso = "srbetanc_api_net/ConsultarPersonajes02",
                    Componente = "ConsultarPersonajes02",
                    Backend = "Api"
                }
            };
            return consultaResponse;
        }
    }
}
