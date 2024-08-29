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

            // Configure relationships and other constraints

            modelBuilder.Entity<CheckHistory>().ToTable("CheckHistory");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CheckHistories)
                .WithOne(ch => ch.User)
                .HasForeignKey(ch => ch.UserId);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.CheckHistories)
                .WithOne(ch => ch.Ticket)
                .HasForeignKey(ch => ch.TicketId);
        }
    }
}
