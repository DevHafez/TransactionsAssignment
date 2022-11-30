using System.ComponentModel.DataAnnotations;

namespace TransactionsAssignment.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
