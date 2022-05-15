using ShoppingBasket.Models;

namespace ShoppingBasket.Interfaces
{
    public interface IBasketItemsDAO
    {
        public Task<bool> AddItems();

        public Task<IEnumerable<BasketItem>> GetItems();

        public Task<bool> DeleteItems();
    }
}
