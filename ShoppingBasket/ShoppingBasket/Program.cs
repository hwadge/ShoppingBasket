using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingBasket.DAL;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LeaderBoardItem;Integrated Security=True"))
            .BuildServiceProvider();
    }
}