using System.Threading.Tasks;

namespace UnknownStore.IdentityServer.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string name, string subject, string message);
    }
}