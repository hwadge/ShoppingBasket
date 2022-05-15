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

        public async Task<double> GetTotalCost(int id)
        {
            double totalPrice = 0;
            var query = await (from b in _context.BasketItem
                               where b.BasketId == id
                               select b).ToListAsync();

            var typeB = query.Where(b => b.Type == "B");

            if (typeB.Any())
            {
                var price = typeB.FirstOrDefault().Price;
                var count = typeB.Count();

                int typeBQuotient = count / 3;
                int typeBRemainder = count % 3;

                totalPrice += typeBQuotient * 40;
                totalPrice += typeBRemainder * price;
            }

            var typeD = query.Where(b => b.Type == "D");

            if (typeD.Any())
            {
                var price = typeD.FirstOrDefault().Price;
                var count = typeD.Count();

                int typeDQuotient = count / 3;
                int typeDRemainder = count % 3;

                totalPrice += typeDQuotient * ((price * 2) * 0.75);
                totalPrice += typeDRemainder * price;
            }

            totalPrice += query.Where(b => b.Type != "B" || b.Type != "D").Sum(b => b.Price);

            return totalPrice;
        }
    }
}
