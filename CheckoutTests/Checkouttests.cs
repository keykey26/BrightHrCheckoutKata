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
        public void ScanAddsMutipleToCheckout()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(new Product("A", 50, 3, 130));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");
            checkoutService.Scan("B");
            checkoutService.Scan("C");
            checkoutService.Scan("D");

            Assert.IsTrue(checkoutService.Products.Count() == 4, "Scan has failed");
        }

        [TestMethod]
        public void ScanNonExsistingSku()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(i => null);

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");

            Assert.IsFalse(checkoutService.Products.Any(), "Scan has added unknown product");
        }

        [TestMethod]
        public void GetTotalPriceTestOneProduct()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(new Product("A", 50, 3, 130));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");

            Assert.IsFalse(checkoutService.GetTotalPrice() == 50, "Price for 1 product is wrong");
        }

        [TestMethod]
        public void GetTotalPriceTestMutipleProduct()
        {
            _productService.GetProduct("A").Returns(new Product("A", 50, 3, 130));
            _productService.GetProduct("B").Returns(new Product("B", 30, 2, 45));
            _productService.GetProduct("C").Returns(new Product("C", 20, 0, 0));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");
            checkoutService.Scan("B");
            checkoutService.Scan("C");

            Assert.IsFalse(checkoutService.GetTotalPrice() == 100, "Price for mutiple products is wrong");
        }

        [TestMethod]
        public void GetTotalPriceTestSpecialOffer()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(new Product("A", 50, 3, 130));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");
            checkoutService.Scan("A");
            checkoutService.Scan("A");

            Assert.IsFalse(checkoutService.GetTotalPrice() == 130, "Price for mutiple products is wrong");
        }

        [TestMethod]
        public void GetTotalPriceTestSpecialOfferWithExtra()
        {
            _productService.GetProduct(Arg.Any<string>()).Returns(new Product("A", 50, 3, 130));

            var checkoutService = new CheckoutService(_productService);

            checkoutService.Scan("A");
            checkoutService.Scan("A");
            checkoutService.Scan("A");
            checkoutService.Scan("A");

            Assert.IsFalse(checkoutService.GetTotalPrice() == 180, "Price for mutiple products is wrong");
        }
    }
}
