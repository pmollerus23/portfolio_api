namespace WebAPI.Services
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using WebAPI.Dtos;
    using WebAPI.Services;

    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailRequest request);
    }

}