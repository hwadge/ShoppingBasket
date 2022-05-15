using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DAL;
using ShoppingBasket.Interfaces;
using ShoppingBasket.Models;
using Z.EntityFramework.Plus;

namespace ShoppingBasket.DAO
{
    public class BasketDAO : IBasketDAO
    {
        private readonly ApplicationDbContext _context;

        public BasketDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBasket(Basket basket)
        {
            await _context.Basket.AddAsync(basket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasket(int id)
        {
            await _context.Basket.Where(b => b.Id == id).DeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalCost(int id)
        {
            var queryResult = await (from b in _context.Basket
                                     where b.Id == id
                                     select b.TotalCost).ToListAsync();

            if (queryResult.Any())
            {
                return queryResult.FirstOrDefault();
            }
            
            return 0;
        }
    }
}
