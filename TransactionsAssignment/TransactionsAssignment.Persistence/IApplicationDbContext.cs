using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;

namespace TransactionsAssignment.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync();
    }
}
