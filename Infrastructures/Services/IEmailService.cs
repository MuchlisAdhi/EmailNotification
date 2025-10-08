using EmailNotification.Domain.Entities;
using EmailNotification.Domain.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Cms;
using MailKit.Net.Smtp;

namespace EmailNotification.Infrastructures.Services;

public interface IEmailService
{
    Task<string> SendEmailAsync(EmailLog mailLog);
}

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;
    private readonly IRazorRendererHelper _razorRenderer;

    public EmailService(IOptions<SmtpSettings> smtpSettings, IRazorRendererHelper razorRenderer)
    {
        _smtpSettings = smtpSettings.Value;
        _razorRenderer = razorRenderer;
    }

    public async Task<string> SendEmailAsync(EmailLog mailLog)
    {
        try
        {
            // Baca template HTML
            string htmlContent = await _razorRenderer.RenderViewToString("~/Infrastructures/Views/EmailNotifications/EmailLog.cshtml", mailLog);

            // Buat objek email
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(mailLog.RecipientEmail));
            email.Subject = mailLog.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = htmlContent };

            // Kirim email menggunakan Mailkit
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTlsWhenAvailable);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return htmlContent; // Kembalikan body HTML yang sudah final untuk disimpan di log
        }
        catch (Exception ex)
        {
            // Handle error (misalnya, logging error)
            Console.WriteLine($"Error sending email: {ex.Message}");
            throw;
        }
    }
}
