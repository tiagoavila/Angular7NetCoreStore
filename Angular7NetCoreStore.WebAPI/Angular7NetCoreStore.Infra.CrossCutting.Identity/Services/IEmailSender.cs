using System.Threading.Tasks;

namespace Angular7NetCoreStore.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
