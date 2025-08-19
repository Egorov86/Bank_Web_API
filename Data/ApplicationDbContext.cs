using _BankWebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _BankWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                        .Property(c => c.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Account>()
                        .Property(a => a.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Account>()
                        .Property(a => a.Balance)
                        .HasDefaultValue(0);

            modelBuilder.Entity<Card>()
                        .Property(c => c.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");
        }
    }
}
