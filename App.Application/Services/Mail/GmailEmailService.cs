using App.Application.Interfaces;

namespace App.Application.Services
{
    public class GmailEmailService : IEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            Console.WriteLine("Gmail ile Email gönderildi");
        }

        public void Send(List<string> toEmails, string subject, string body)
        {
            Console.WriteLine("Gmail ile toplu email gönderildi");
        }
    }
}
