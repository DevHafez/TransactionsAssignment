using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.TransactionFeatures.Queries
{
    public class GetTransactioByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
        public class GetTransactioByIdQueryHandler : IRequestHandler<GetTransactioByIdQuery, Transaction>
        {
            private readonly IApplicationDbContext _context;
            public GetTransactioByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Transaction> Handle(GetTransactioByIdQuery request, CancellationToken cancellationToken)
            {
                var transaction = _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefault();
                if (transaction == null) return null;
                return transaction;
            }
        }
    }
}
