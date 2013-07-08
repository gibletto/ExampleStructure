using System.Linq;
using Core.Domain.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    //You can even test persistence with an in memory database like SQLLite.
    public class ProductTests
    {
        [TestCategory("CoreTests")]
        [TestMethod]
        public void TestMethod()
        {
            var product = new Product("123", "MyProduct");
            product.AddStore(new Store("MyStore"));
            Assert.IsTrue(product.Stores.Any());
        }
    }
}
