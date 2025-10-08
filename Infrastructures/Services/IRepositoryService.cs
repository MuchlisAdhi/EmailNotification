using EmailNotification.Domain.Context;
using EmailNotification.Domain.Entities;
using EmailNotification.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailNotification.Infrastructures.Services;

public interface IRepositoryService
{
    Task<Result> SaveEmailLog(EmailLog emailLog, CancellationToken cancellationToken);
    Task<List<EmailLog>> GetEmailLogs();
}

public class RepositoryService(IDataContext _context) : IRepositoryService
{
    public async Task<List<EmailLog>> GetEmailLogs()
    {
        var emailLogs = await _context.EmailLogs
                                        .OrderByDescending(log => log.SentAt)
                                        .ToListAsync();

        return emailLogs;
    }

    public async Task<Result> SaveEmailLog(EmailLog emailLog, CancellationToken cancellationToken)
    {
        try
        {
            if (emailLog.Key == Guid.Empty)
            {
                emailLog.Key = Guid.NewGuid();
            }

            //Check if Email Logs is exists
            var existingLog = await _context.EmailLogs.FirstOrDefaultAsync(x => x.Key == emailLog.Key);
            if (existingLog == null)
            {
                //Add new Email Logs
                _context.EmailLogs.Add(emailLog);
            }
            else
            {
                _context.EmailLogs.Entry(existingLog).CurrentValues.SetValues(emailLog);
            }

            var result = await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            return Result.Failure(new[] { ex.Message });
        }

        return Result.Success();
    }
}
