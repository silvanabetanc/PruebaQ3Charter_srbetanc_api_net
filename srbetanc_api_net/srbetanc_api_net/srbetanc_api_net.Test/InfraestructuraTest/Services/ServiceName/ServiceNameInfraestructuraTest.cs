using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.Functional;
using Moq;
using NUnit.Framework;
using srbetanc_api_net.Domain.Interfaces.Services.ServiceName;
using srbetanc_api_net.Entity.Services.ServiceName.Entrada;
using srbetanc_api_net.Entity.Services.ServiceName.Salida;
using srbetanc_api_net.Infrastructure.Services.ServiceName;
using srbetanc_api_net.Test.Utilitarios.Services.ServiceName;

namespace srbetanc_api_net.Test.InfraestructuraTest.Services.ServiceName
{
    public class ServiceNameInfraestructuraTest
    {
        #region Private

        /// <summary>
        /// 
        /// </summary>
        private DataEntrada dataEntrada;

        /// <summary>
        /// 
        /// </summary>
        private Mock<IServiceNameRepositorio> _mockIServiceNameRepositorio;

        /// <summary>
        /// 
        /// </summary>
        private IServiceNameInfraestructura _iServiceNameInfraestructura;
        /// <summary>
        /// 
        /// </summary>
        private Either<EError, ERespuesta<ETarjetas>> result;

        #endregion Private

        [SetUp]
        public void Setup()
        {
            dataEntrada = new DataEntrada();

            _mockIServiceNameRepositorio = new Mock<IServiceNameRepositorio>();

            _iServiceNameInfraestructura = new ServiceNameInfraestructura(_mockIServiceNameRepositorio.Object);

            _mockIServiceNameRepositorio.Setup(r => r.EjecutarConsultaEstadosCuentasTarjetasCredito(It.IsAny<EEntrada<EProveedor>>())).ReturnsAsync(result);
            _mockIServiceNameRepositorio.Verify();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Obtener_ConsultaEstadosCuentasTarjetasCredito_ReturnsListaTarjetas()
        {

            // Act
            var respuesta = _iServiceNameInfraestructura.ConsultarTarjetas(dataEntrada._eProveedor);

            // Assert
            Assert.DoesNotThrowAsync(async () => await respuesta);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Obtener_ConsultaEstadosCuentasTarjetasCredito_ReturnsCoreNegocioError()
        {
            // Arrange
            dataEntrada._eProveedor.HeaderIn = null;

            // Act            
            var ex = _iServiceNameInfraestructura.ConsultarTarjetas(dataEntrada._eProveedor);

            // Assert
            Assert.ThrowsAsync<CoreNegocioError>(async () => await ex);

        }
    }
}
