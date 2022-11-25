using BP.API.Entidades.Excepciones;
using NUnit.Framework;
using srbetanc_api_net.Domain.Interfaces.Services.rickandmortyapi;
using srbetanc_api_net.Repository.Services.rickandmortyapi;

namespace srbetanc_api_net.Test.RepositorioTest.Services.rickandmortyapi
{
    public class ConsultarPersonajesRepositorioTest
    {
        private IConsultarPersonajesRepositorio iConsultarPersonajesRepositorio;

        [SetUp]
        public void Setup()
        {
            iConsultarPersonajesRepositorio = new ConsultarPersonajesRepositorio();
        }

        [Test]
        public void ConsultarPersonajes_ReturnsError()
        {
            bool bandera = false;
            Assert.ThrowsAsync<CoreNegocioError>(async () => (await iConsultarPersonajesRepositorio.EjecutarConsultaPersonajes()).Match(
                  Right: x =>
                  {
                      _ = x;
                      bandera = true;
                  },
                 Left: x =>
                 {
                     bandera = false;
                 }));
            Assert.AreEqual(false, bandera);
        }


    }
}
