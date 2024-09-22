
using SellerBuyer.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using SellerBuyer.Service;

namespace SellerBuyerTest
{
    [TestClass]
    public class SellerTest
    {

        private SellerService _service;

        [TestInitialize]
        public void Setup()
        {
            var context = new DB("",true);
            context.Seller.Add(new Seller() {SellerId = 1, Name = "Pratik" });
            context.Seller.Add(new Seller() { SellerId = 2, Name = "Raju" });
            context.SaveChanges();
            _service = new SellerService(context);
        }

        [TestMethod]
        public void TestPostSellers()
        {
            _service.NewSeller(new SellerParams() { SellerName = "Rajiv" });
            var sellers = _service.GetSellers();
            Assert.AreEqual(3, sellers.Count());
        }
    }
}