using Domen.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {

        }

        public DbSet<MatchHistory> MatchHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<UserMatchHistory> UserMatchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserMatchHistory>()
                .HasKey(um => new { um.UserID, um.MatchHistoryID });

            modelBuilder.Entity<UserMatchHistory>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMatchHistory)
                .HasForeignKey(u => u.UserID);

            modelBuilder.Entity<UserMatchHistory>()
                .HasOne(um => um.MatchHistory)
                .WithMany(u => u.UserMatchHistory)
                .HasForeignKey(u => u.MatchHistoryID);


            modelBuilder.Entity<MatchHistory>()
                .HasMany(m => m.Bets)
                .WithOne(b => b.MatchHistory)
                .HasForeignKey(b => b.IDofMatchHistory);
        }
    }
}
