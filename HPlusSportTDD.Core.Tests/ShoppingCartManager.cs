
using NUnit.Framework.Constraints;

namespace HPlusSportTDD.Core
{
    internal class ShoppingCartManager

    {
        public ShoppingCartManager()
        {
        }

        private List<AddToCartItem> _items = new List<AddToCartItem>();

        internal AddToCartResponse AddToCart(AddToCartRequest request)
        {
            _items.Add(request.Item);
            return new AddToCartResponse { Items = _items.ToArray<AddToCartItem>() };
        }
    }
}