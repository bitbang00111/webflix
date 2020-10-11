using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevOpsDemo.Web;
using DevOpsDemo.Web.Controllers;

namespace DevOpsDemo.Web.Tests.Controllers
{
    [TestClass]
    public class ActorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ActorController controller = new ActorController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
