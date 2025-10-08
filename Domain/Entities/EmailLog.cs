using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmailNotification.Domain.Entities;

[Table("tbtemaillog", Schema = "Transaction")]
public class EmailLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Key { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string SenderEmail { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string SenderName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public required string RecipientEmail { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string ReceiverName { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public required string Subject { get; set; }

    [Required]
    public required string Body { get; set; }

    [Required]
    public DateTime SentAt { get; set; }
}
