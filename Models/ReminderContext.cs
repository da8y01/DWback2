using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Reminders1.Models
{
    public class ReminderContext : DbContext
    {
        public ReminderContext(DbContextOptions<ReminderContext> options)
            : base(options)
        {
        }

        public DbSet<ReminderItem> ReminderItems { get; set; } = null!;
    }
}