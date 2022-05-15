using ShoppingBasket.DAL;
using ShoppingBasket.Interfaces;

namespace ShoppingBasket.DAO
{
    public class BasketDAO : IBasketDAO
    {
        private readonly ApplicationDbContext _context;

        public BasketDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBasket()
        {

        }

        public async Task<bool> DeleteBasket()
        {

        }
    }
}
