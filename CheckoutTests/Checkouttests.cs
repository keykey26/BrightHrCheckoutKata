using BrightHrCheckoutKata.Models;
using BrightHrCheckoutKata.Services;
using NSubstitute;

namespace CheckoutTests
{
    [TestClass]
    public sealed class Checkouttests
    {
        private IProductService _productService;

        public Checkouttests()
        {
            _productService = Substitute.For<IProductService>();
        }

        [TestMethod]
        public void ScanAddsToCheckout()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(new Product("A", 50, 3, 130));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");

            Assert.IsTrue(checkoutService.Products.Any(), "Scan has failed");
        }

        [TestMethod]
        public void ScanNonExsistingSku()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(i => null);

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");

            Assert.IsFalse(checkoutService.Products.Any(), "Scan has added unknown product");
        }
    }
}
