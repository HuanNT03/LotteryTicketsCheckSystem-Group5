using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<LotteryCompany> LotteryCompanies { get; set; }
    public DbSet<LotteryTicket> LotteryTickets { get; set; }
    public DbSet<TicketResult> TicketResults { get; set; }
    public DbSet<CheckHistory> CheckHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<LotteryTicket>()
            .HasKey(t => t.TicketId);

        modelBuilder.Entity<LotteryTicket>()
            .HasOne(t => t.LotteryCompany)
            .WithMany(c => c.LotteryTickets)
            .HasForeignKey(t => t.CompanyId);

        modelBuilder.Entity<CheckHistory>()
            .HasKey(ch => ch.CH_Id);

        modelBuilder.Entity<CheckHistory>()
            .HasOne(ch => ch.User)
            .WithMany(u => u.CheckHistories)
            .HasForeignKey(ch => ch.UserId);

        modelBuilder.Entity<CheckHistory>()
            .HasOne(ch => ch.LotteryTicket)
            .WithMany(t => t.CheckHistories)
            .HasForeignKey(ch => ch.LotteryTicketId);

        modelBuilder.Entity<TicketResult>()
            .HasKey(tr => tr.Id);

        modelBuilder.Entity<TicketResult>()
            .HasOne(tr => tr.LotteryTicket)
            .WithMany(t => t.TicketResults)
            .HasForeignKey(tr => tr.TicketId);
    }
}
