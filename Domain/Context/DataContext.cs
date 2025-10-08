using EmailNotification.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailNotification.Domain.Context;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    private static ValueConverter DateTimeConvert()
        => new ValueConverter<DateTime, DateTime>(
            x => x.ToUniversalTime(),
            x => x.ToLocalTime()
        );

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("public");

        builder.Entity<EmailLog>().Property(x => x.SentAt)
                                       .HasConversion(DateTimeConvert())
                                       .HasColumnType("timestamp with time zone")
                                       .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'Asia/Jakarta'");
        base.OnModelCreating(builder);
    }

    public DbSet<EmailLog> EmailLogs => Set<EmailLog>();
}
