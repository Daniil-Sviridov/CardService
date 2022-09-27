using Microsoft.EntityFrameworkCore;

namespace CardStorageService.Data
{
    public class SampleServiceDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Cards> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSession> AccountSessions { get; set; }

        public SampleServiceDbContext(DbContextOptions options) : base(options) { }
    }
}