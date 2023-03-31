using CapaPresentacionAdmin.Controllers;
using CapaPresentacionAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework.Internal;
using System.Web.Mvc;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject1
{
    public class UnitTest1
    {

        [TestMethod]
        public void SetEstadoToPausada()
        {
            // Arrange
            var ordenProduccion = new OrdenProduccion { NumeroOP = 10, NumeroLinea = 4, IdModelo = 1, Codigo = 6, Estado = "Iniciada", SupervisorLinea= 41987321 };
            var dbMock = new Mock<FabricaCalzadosDB>();
            dbMock.Setup(x => x.OrdenProduccion.Find(10)).Returns(ordenProduccion);
            var controller = new OrdenesProduccionController(dbMock.Object);

            // Act
            var result = controller.Pausar(10) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Pausada", ordenProduccion.Estado);
        }

    }
}