using ShoppingBasket.Models;

namespace ShoppingBasket.Interfaces
{
    public interface IBasketDAO
    {
        public Task CreateBasket(Basket basket);

        public Task DeleteBasket(int id);

        public Task<double> GetTotalCost(int id);
    }
}
