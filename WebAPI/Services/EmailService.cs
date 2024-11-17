namespace WebAPI.Services
{
    using WebAPI.Services;
    using WebAPI.Dtos;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _email = "pmollerus23@gmail.com"; // Your Gmail address
        private readonly string _password = "utot aupc qato saeo"; // Your Gmail password or App password

        public async Task SendEmailAsync(SendEmailRequest request)
        {
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress(request.From),
                From = new MailAddress(request.From),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(_email);

            using var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_email, _password),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}