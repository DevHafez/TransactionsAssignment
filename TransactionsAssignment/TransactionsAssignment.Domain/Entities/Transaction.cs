using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsAssignment.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {

        }
        public string BeneficiaryName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Direction { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Kind { get; set; }
    }
}
