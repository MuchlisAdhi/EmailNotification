using EmailNotification.Domain.Entities;

namespace EmailNotification.Domain.Dtos;

public class EmailLogDto
{
    public Guid? Key { get; set; } = Guid.Empty;
    public string SenderEmail { get; set; } = null!;
    public string SenderName { get; set; } = null!;
    public required string RecipientEmail { get; set; } = null!;
    public string ReceiverName { get; set; } = null!;
    public required string Subject { get; set; }
    public string? Body { get; set; } = String.Empty;
    public DateTime SentAt { get; set; } = DateTime.Now;

    public EmailLog ConvertToEntity()
    {
        return new EmailLog
        {
            Key = this.Key ?? Guid.Empty,
            SenderEmail = this.SenderEmail,
            SenderName = this.SenderName,
            RecipientEmail = this.RecipientEmail,
            ReceiverName = this.ReceiverName,
            Subject = this.Subject,
            Body = this.Body ?? String.Empty,
            SentAt = this.SentAt
        };
    }
}
