using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlusSportTDD.Core
{
    internal class ShoppingCartTests
    {
        [SetUp]
        public void Setup() 
        {

        }

        [Test]
        public void ShouldReturnArticleAddedToCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            Assert.NotNull(response);
            Assert.Contains(item, response.Items);
        }

        [Test]
        public void ShouldReturnArticlesAddedToCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var item2 = new AddToCartItem()
            {
                ArticleId = 43,
                Quantity = 10
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var request2 = new AddToCartRequest()
            {
                Item = item2
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);
            response = manager.AddToCart(request2);

            Assert.NotNull(response);
            Assert.Contains(item, response.Items);
            Assert.Contains(item2, response.Items);
        }

        [Test]
        public void ShouldUpdateQuantityOfSameItemAddedToList()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var item2 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 10
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var request2 = new AddToCartRequest()
            {
                Item = item2
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);
            response = manager.AddToCart(request2);

            Assert.NotNull(response);
            Assert.That(Array.Exists(response.Items, item => item.ArticleId == 42 && item.Quantity == 15));

        }

    }
}
