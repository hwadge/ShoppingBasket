namespace ShoppingBasket.Interfaces
{
    public interface IBasketDAO
    {
        public Task<bool> CreateBasket();

        public Task<bool> DeleteBasket();
    }
}
