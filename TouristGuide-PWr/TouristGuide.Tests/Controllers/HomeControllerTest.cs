using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using TouristGuide;
using TouristGuide.Controllers;
using TouristGuide.Models;
using TouristGuide.Tests.Models;
using System.Web.Routing;
using Rhino.Mocks;
using System.Web;

namespace TouristGuide.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController controller;

        [SetUp]
        public void HomeControllerTestSetUp()
        {
            controller = new HomeController(new MockTouristGuideDB());
            var routeData = new RouteData();
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            FormCollection formParameters = new FormCollection();
            ControllerContext controllerContext =
            MockRepository.GenerateStub<ControllerContext>(httpContext, routeData, controller);
            controller.ControllerContext = controllerContext;
            controller.ValueProvider = formParameters.ToValueProvider();
        }

        [Test]
        public void Index()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Asserts
            Assert.IsNotNull(result);
            var model = result.Model;
            Assert.IsNotNull(model);
        }

        [Test]
        public void About()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Asserts
            Assert.IsNotNull(result);
            var model = result.Model;
            Assert.IsNull(model);
        }

        [Test]
        public void Mobile()
        {
            // Act
            ViewResult result = controller.Mobile() as ViewResult;

            // Asserts
            Assert.IsNotNull(result);
            var model = result.Model;
            Assert.IsNull(model);
        }

        [Test]
        public void Contact()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Asserts
            Assert.IsNotNull(result);
            var model = result.Model;
            Assert.IsNull(model);
        }
    }
}
