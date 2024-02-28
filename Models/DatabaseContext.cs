using Microsoft.EntityFrameworkCore;

namespace S5L3.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-MARCO\\SQLEXPRESS;Database=Scarpe&Co;Integrated Security=True;");
            }
        }
    }
}