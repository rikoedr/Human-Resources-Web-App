using API.Contracts;
using System.Net.Mail;

namespace API.Utilities.Handlers;

public class EmailHandler : IEmailHandler
{
    private string server;
    private int port;
    private string fromEmailAddress;

    public EmailHandler(string server, int port, string fromEmailAddress)
    {
        this.server = server;
        this.port = port;
        this.fromEmailAddress = fromEmailAddress;
    }

    public void Send(string subject, string body, string toEmail)
    {
        MailMessage message = new MailMessage()
        {
            From = new MailAddress(fromEmailAddress),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        message.To.Add(new MailAddress(toEmail));

        using var smtpClient = new SmtpClient(server, port);
        smtpClient.Send(message);
    }
}
