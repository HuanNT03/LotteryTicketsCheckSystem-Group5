using LotteryBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LotteryBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LotteryCompany> LotteryCompanies { get; set; }
        public DbSet<LotteryResult> LotteryResults { get; set; }
        public DbSet<CheckHistory> CheckHistories { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // LotteryCompany and LotteryTicket: 1-n relationship
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.LotteryCompany)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.LotteryCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ticket and LotteryResult: 1-n relationship
            modelBuilder.Entity<LotteryResult>()
                .HasOne(r => r.Ticket)
                .WithMany(t => t.LotteryResults)
                .HasForeignKey(r => r.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // User and CheckHistory: 1-n relationship
            modelBuilder.Entity<CheckHistory>()
                .HasOne(ch => ch.User)
                .WithMany(u => u.CheckHistories)
                .HasForeignKey(ch => ch.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ticket and CheckHistory: 1-n relationship
            modelBuilder.Entity<CheckHistory>()
                .HasOne(ch => ch.Ticket)
                .WithMany(t => t.CheckHistories)
                .HasForeignKey(ch => ch.TicketId)
                .OnDelete(DeleteBehavior.Cascade);


            //Fake data
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserName = "admin" },
                new User { UserName = "user1" }
            );

            modelBuilder.Entity<LotteryCompany>().HasData(
                new LotteryCompany { Id = 1, Name = "Company A", Address = "City A", Phone = "0123456789" },
                new LotteryCompany { Id = 2, Name = "Company B", Address = "City B", Phone = "0123498765" }
            );

            // Seed LotteryTickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, LotteryCompanyId = 1, LotteryDate = new DateTime(2024, 8, 20), Status = TicketStatus.PUBLISH },
                new Ticket { Id = 2, LotteryCompanyId = 2, LotteryDate = new DateTime(2024, 8, 21), Status = TicketStatus.PUBLISH },
                new Ticket { Id = 3, LotteryCompanyId = 1, LotteryDate = new DateTime(2024, 8, 22), Status = TicketStatus.UNPUBLISH }
            );

            // Seed LotteryResults
            modelBuilder.Entity<LotteryResult>().HasData(
                new LotteryResult { Id = 1, TicketId = 1, PrizeCategory = "Giải đặc biệt", WinningNumber = "123456" },
                new LotteryResult { Id = 2, TicketId = 1, PrizeCategory = "Giải nhất", WinningNumber = "23456" },
                new LotteryResult { Id = 3, TicketId = 1, PrizeCategory = "Giải nhì", WinningNumber = "34567" },
                new LotteryResult { Id = 4, TicketId = 2, PrizeCategory = "Giải ba", WinningNumber = "654321" },
                new LotteryResult { Id = 5, TicketId = 2, PrizeCategory = "Giải nhất", WinningNumber = "54321" },
                new LotteryResult { Id = 6, TicketId = 2, PrizeCategory = "Giải nhì", WinningNumber = "43210" }
            );
        }
    }

}
