using ShoppingBasket.DAL;
using ShoppingBasket.Interfaces;
using ShoppingBasket.Models;

namespace ShoppingBasket.DAO
{
    public class BasketItemDAO : IBasketItemDAO
    {
        private readonly ApplicationDbContext _context;

        public BasketItemDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItems(IEnumerable<BasketItem> items)
        {
            return true;
        }

        public async Task<IEnumerable<BasketItem>> GetItems(IEnumerable<int> ids)
        {
            return new List<BasketItem>();
        }

        public async Task<bool> DeleteItems(IEnumerable<int> ids)
        {
            return true;
        }
    }
}
