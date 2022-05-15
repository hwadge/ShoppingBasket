using ShoppingBasket.Models;

namespace ShoppingBasket.Interfaces
{
    public interface IBasketItemDAO
    {
        public Task<bool> AddItems(IEnumerable<BasketItem> items);

        public Task<IEnumerable<BasketItem>> GetItems(IEnumerable<int> ids);

        public Task<bool> DeleteItems(IEnumerable<int> ids);
    }
}
