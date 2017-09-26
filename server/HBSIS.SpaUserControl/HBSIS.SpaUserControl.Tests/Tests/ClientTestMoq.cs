using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBSIS.SpaUserControl.Application.Interfaces;
using HBSIS.SpaUserControl.Application.Services;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.Domain.Models;
using HBSIS.SpaUserControl.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HBSIS.SpaUserControl.Tests.Tests
{
    [TestClass]
    public class ClientTestMoq
    {
        private ClientsController _target;
        private readonly Mock<IClientAppService> _mock;

        public ClientTestMoq()
        {
            _mock = new Mock<IClientAppService>();
            _target = new ClientsController(_mock.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void AddAValidClientTest()
        {
            // Arrange
            var validClientViewModel = new ClientViewModel { Name = "Cliente Teste", PhoneNumber = "11999998888", Email = "cliente@teste.com", DocumentNumber = "23867620000125" };

            //Act
            var response = _target.Post(validClientViewModel);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void AddAInvalidClientTest()
        {
            //Arrange
            var invalidClientViewModel = new ClientViewModel { Name = "", PhoneNumber = "", Email = "cliente@teste.com", DocumentNumber = "23867620000125" };
            
            //Act
            var response = _target.Post(invalidClientViewModel);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
