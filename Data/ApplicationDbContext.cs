using LotteryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LotteryResult> LotteryResults { get; set; }
        public DbSet<CheckHistory> CheckHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and other constraints here if needed
        }
    }

}
