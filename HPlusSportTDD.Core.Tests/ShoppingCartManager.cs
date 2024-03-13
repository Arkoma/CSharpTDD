
using NUnit.Framework.Constraints;

namespace HPlusSportTDD.Core
{
    internal class ShoppingCartManager

    {
        private List<AddToCartItem> _shoppingCart;

        public ShoppingCartManager()
        {
            _shoppingCart = new List<AddToCartItem>();
        }


        internal AddToCartResponse AddToCart(AddToCartRequest request)
        {
            var existingItem = _shoppingCart.FirstOrDefault(x => x.ArticleId == request.Item.ArticleId);
            if (existingItem != null)
            {
                existingItem.Quantity += request.Item.Quantity;
            } else
            {
                _shoppingCart.Add(request.Item);
            }
            return new AddToCartResponse { Items = _shoppingCart.ToArray<AddToCartItem>() };
        }
    }
}