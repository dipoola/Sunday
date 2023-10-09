using Microsoft.EntityFrameworkCore;

namespace Sunday.Models
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dipps> Olawale {  get; set; }
    }
}
