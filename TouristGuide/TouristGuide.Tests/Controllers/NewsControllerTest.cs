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

namespace TouristGuide.Tests
{
    
    [TestFixture]
    public class NewsControllerTest
    {
        private NewsController controller;

        [SetUp]
        public void NewsControllerTestSetUp()
        {
            controller = new NewsController(new MockTouristGuideDB());
            var routeData = new RouteData();
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            FormCollection formParameters = new FormCollection();
            ControllerContext controllerContext =
            MockRepository.GenerateStub<ControllerContext>(httpContext, routeData, controller);
            controller.ControllerContext = controllerContext;
            controller.ValueProvider = formParameters.ToValueProvider();
        }

        [Test]
        public void CreateTest()
        {
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Asserts
            Assert.IsNotNull(result);
            var model = result.Model;
            Assert.IsNotNull(model);
            Assert.IsInstanceOf<NewsTimeViewModel>(model);
            Assert.IsNotNull(((NewsTimeViewModel)model).News);
        }

        [Test]
        public void CreateTest1()
        {
            // Act
            NewsTimeViewModel newNews = new NewsTimeViewModel();
            try
            {
                ViewResult result = controller.Create(newNews) as ViewResult;
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void IndexTest()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void DetailsExistsTest()
        {
            // Act
            controller.db.News.Add(new News { ID = 1, Date = DateTime.Now, Text = "txt", Title = "title" });
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void DetailsNotExistsTest()
        {
            // Act
            RedirectToRouteResult result = controller.Details(1) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void DeleteTest()
        {
            // Act
            controller.db.News.Add(new News { ID = 1, Date = DateTime.Now, Text = "txt", Title = "title" });
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void DeletePostTest()
        {
            // Act
            controller.db.News.Add(new News { ID = 1, Date = DateTime.Now, Text = "txt", Title = "title" });
            RedirectToRouteResult result = controller.Delete(1, new FormCollection()) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
