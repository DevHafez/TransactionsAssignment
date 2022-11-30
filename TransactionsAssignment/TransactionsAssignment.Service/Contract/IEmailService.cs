using System.Threading.Tasks;
using TransactionsAssignment.Domain.Settings;

namespace TransactionsAssignment.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
