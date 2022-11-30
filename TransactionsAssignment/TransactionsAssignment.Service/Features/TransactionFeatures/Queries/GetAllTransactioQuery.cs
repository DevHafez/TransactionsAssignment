using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.TransactionFeatures.Queries
{
    public class GetAllTransactioQuery : IRequest<IEnumerable<Transaction>>
    {
        public string Kind { get; set; }
        public class GetAllTransactioQueryHandler : IRequestHandler<GetAllTransactioQuery, IEnumerable<Transaction>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTransactioQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Transaction>> Handle(GetAllTransactioQuery request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Kind))
                {
                    return await _context.Transactions.ToListAsync();
                }
                else
                {
                   return await _context.Transactions.Where(x => x.Kind == request.Kind).OrderByDescending(x=>x.TransactionDate).ToListAsync();
                }
            }
        }
    }
}
