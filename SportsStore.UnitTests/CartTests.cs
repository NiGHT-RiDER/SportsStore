using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {


        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // arrange
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Cart c = new Cart();

            //act 
            c.AddItem(p1, 1);
            c.AddItem(p2, 1);
            CartLine[] lines = c.Lines.ToArray();

            // assert
            Assert.AreEqual(lines.Length, 2);
            Assert.AreEqual(lines[0].Product, p1);
            Assert.AreEqual(lines[1].Product, p2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // arrange
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Cart c = new Cart();

            // act
            c.AddItem(p1, 1);
            c.AddItem(p1, 10);
            CartLine[] results = c.Lines.OrderBy(x => x.Product.ProductID).ToArray();

            // assert 
            Assert.IsTrue(results[0].Product == p1);
            Assert.IsTrue(results[0].Quantity == 11);
        }   

        [TestMethod]
        public void Can_Remove_Line()
        {
            // arrange
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Cart c = new Cart();

            //act
            c.AddItem(p1, 1);
            c.AddItem(p2, 1);
            c.RemoveLine(p1);
            CartLine[] results = c.Lines.OrderBy(x => x.Product.ProductID).ToArray();

            //assert
            Assert.IsTrue(results.Length == 1);
            Assert.IsTrue(results.Where(x => x.Product.ProductID == 1).Count() == 0);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // arrange 
            Product p1 = new Product { ProductID = 1, Name = "p1", Price = 100 };
            Product p2 = new Product { ProductID = 2, Name = "p2", Price = 100 };
            Cart c = new Cart();

            //act 
            c.AddItem(p1, 5);
            c.AddItem(p2, 5);

            //assert
            Assert.IsTrue(c.ComputeTotalValue() == 1000);

        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            //arrange
            Product p1 = new Product { ProductID = 1, Name = "p1", Price = 100 };
            Product p2 = new Product { ProductID = 2, Name = "p2", Price = 100 };
            Cart c = new Cart();

            // act
            c.AddItem(p1, 1);
            c.AddItem(p2, 1);
            c.Clear();

            // assert
            Assert.IsTrue(c.Lines.Count() == 0);
        }

        [TestMethod]
        public void Can_Add_To_Cart()
        {

        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
        }

        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {

        }

        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {

        }

        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
        }

    }
}

