using ShoppingBasket.DAL;
using ShoppingBasket.Interfaces;

namespace ShoppingBasket.DAO
{
    public class BasketItemDAO : IBasketItemsDAO
    {
        private readonly ApplicationDbContext _context;

        public BasketItemDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItems()
        {

        }

        public async Task<bool> GetItems()
        {

        }

        public async Task<bool> DeleteItems()
        {

        }
    }
}
