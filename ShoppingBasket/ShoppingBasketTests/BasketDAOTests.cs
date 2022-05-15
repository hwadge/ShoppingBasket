using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DAL;
using ShoppingBasket.DAO;
using ShoppingBasket.Models;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingBasketTests
{
    public class BasketDAOTests
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<ApplicationDbContext> _contextOptions;

        public BasketDAOTests()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new ApplicationDbContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                context.AddRange(
                new Basket { Id = 1 });
                context.SaveChanges();
            }
        }

        ApplicationDbContext CreateContext() => new ApplicationDbContext(_contextOptions);

        public void Dispose() => _connection.Dispose();

        [Fact]
        public async Task GivenMultipleOf3BItemsInBasket_ThenPromoApplied()
        {
            using var context = CreateContext();

            context.AddRange(
                new BasketItem { Id = 1, BasketId = 1, Price = 15, Type = "B" },
                new BasketItem { Id = 2, BasketId = 1, Price = 15, Type = "B" },
                new BasketItem { Id = 3, BasketId = 1, Price = 15, Type = "B" });
            context.SaveChanges();

            var sut = new BasketDAO(context);

            var result = await sut.GetTotalCost(1);

            Assert.Equal(40, result);
        }

        [Fact]
        public async Task GivenMultipleOf2DItemsInBasket_ThenPromoApplied()
        {
            using var context = CreateContext();

            context.AddRange(
                new BasketItem { Id = 2, BasketId = 1, Price = 55, Type = "D" },
                new BasketItem { Id = 3, BasketId = 1, Price = 55, Type = "D" });
            context.SaveChanges();

            var sut = new BasketDAO(context);

            var result = await sut.GetTotalCost(1);

            Assert.Equal(82.5, result);
        }
    }
}
