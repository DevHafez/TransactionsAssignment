using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.CustomerFeatures.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Customer>>
    {

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Customer>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCustomerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var customerList = await _context.Customers.ToListAsync();
                if (customerList == null)
                {
                    return null;
                }
                return customerList.AsReadOnly();
            }
        }
    }
}
