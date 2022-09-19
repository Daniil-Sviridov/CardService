using Microsoft.EntityFrameworkCore;

namespace CardStorageService.Data
{
    public class SampleServiceDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Cards> Cards { get; set; }

        public SampleServiceDbContext(DbContextOptions options) : base(options) { }
    }
}