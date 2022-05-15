using Microsoft.EntityFrameworkCore;
using ShoppingBasket.Models;

namespace ShoppingBasket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
    }
}
