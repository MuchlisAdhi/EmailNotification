using EmailNotification.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailNotification.Domain.Context;

public interface IDataContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DbSet<EmailLog> EmailLogs { get; }
}
