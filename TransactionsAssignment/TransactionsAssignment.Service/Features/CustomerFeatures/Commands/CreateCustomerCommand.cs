using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.CustomerFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.CustomerName = request.CustomerName;
                customer.ContactName = request.ContactName;

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}
