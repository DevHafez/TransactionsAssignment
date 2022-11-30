using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertCustomerIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            var customer = new Customer();
            context.Customers.Add(customer);
            Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
        }
    }
}
