using App.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace App.Application.Services
{
    public class SmtpEmailService : IEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient("sunucu", 587);
                client.Credentials = new NetworkCredential("mail", "şifre");
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mail");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;
                client.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

        public void Send(List<string> toEmails, string subject, string body)
        {
            Console.WriteLine("SMTP ile toplu email gönderildi");
        }
    }
}
