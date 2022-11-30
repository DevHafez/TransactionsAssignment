using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.TransactionFeatures.Commands
{
    public class DeleteTransactioByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTransactiorByIdCommandHandler : IRequestHandler<DeleteTransactioByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTransactiorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTransactioByIdCommand request, CancellationToken cancellationToken)
            {
                var transaction = await _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (transaction == null) return default;
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return transaction.Id;
            }
        }
    }
}
