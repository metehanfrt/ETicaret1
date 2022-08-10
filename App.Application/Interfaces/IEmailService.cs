namespace App.Application.Interfaces
{
    public interface IEmailService
    {
        void Send(string toEmail, string subject, string body);

        void Send(List<string> toEmails, string subject, string body);
    }
}
