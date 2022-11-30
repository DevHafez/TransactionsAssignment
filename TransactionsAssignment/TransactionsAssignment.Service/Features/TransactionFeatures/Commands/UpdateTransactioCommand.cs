using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.TransactionFeatures.Commands
{
    public class UpdateTransactioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string BeneficiaryName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Direction { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Kind { get; set; }
        public class UpdateTransactioCommandHandler : IRequestHandler<UpdateTransactioCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTransactioCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTransactioCommand request, CancellationToken cancellationToken)
            {
                var transaction = _context.Transactions.Where(a => a.Id == request.Id).FirstOrDefault();

                if (transaction == null)
                {
                    return default;
                }
                else
                {
                    transaction.TransactionDate = request.TransactionDate;
                    transaction.Amount = request.Amount;
                    transaction.BeneficiaryName = request.BeneficiaryName;
                    transaction.Currency = request.Currency;
                    transaction.Direction = request.Direction;
                    transaction.Kind = request.Kind;
                    _context.Transactions.Update(transaction);
                    await _context.SaveChangesAsync();
                    return transaction.Id;
                }
            }
        }
    }
}
