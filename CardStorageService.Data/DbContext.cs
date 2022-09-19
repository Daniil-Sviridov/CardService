using Microsoft.EntityFrameworkCore;

namespace CardStorageService.Data
{
    public class SampleServiceDbContext : DbContext
    {
        public SampleServiceDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
