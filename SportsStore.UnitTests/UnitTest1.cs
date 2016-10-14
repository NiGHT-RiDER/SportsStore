using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Moq;
using Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID = 1 , Name = "p1" },
                new Product { ProductID = 2 , Name = "p2" },
                new Product { ProductID = 3 , Name = "p3" },
                new Product { ProductID = 4 , Name = "p4" },
                new Product { ProductID = 5 , Name = "p5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            // assert
            //Product[] prodArray = result.ToArray();
            //Assert.IsTrue(prodArray.Length == 2);
            //Assert.AreEqual(prodArray[0].Name, "p4");
            //Assert.AreEqual(prodArray[1].Name, "p5");
        }
    }
}
