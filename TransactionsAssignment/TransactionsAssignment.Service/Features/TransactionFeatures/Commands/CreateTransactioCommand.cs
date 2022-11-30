using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.TransactionFeatures.Commands
{
    public class CreateTransactioCommand : IRequest<int>
    {
        public string BeneficiaryName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Direction { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Kind { get; set; }
        public class CreateTransactioCommandHandler : IRequestHandler<CreateTransactioCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateTransactioCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateTransactioCommand request, CancellationToken cancellationToken)
            {
                var transaction = new Transaction();
                transaction.TransactionDate = request.TransactionDate;
                transaction.Amount = request.Amount;
                transaction.BeneficiaryName = request.BeneficiaryName;
                transaction.Currency = request.Currency;
                transaction.Direction = request.Direction;
                transaction.Kind = request.Kind;
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return transaction.Id;
            }
        }
    }
}
