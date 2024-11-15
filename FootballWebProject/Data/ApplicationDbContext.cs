using Microsoft.EntityFrameworkCore;
using FootballWebProject.Models;
namespace FootballWebProject.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

       public DbSet<Teams> Teams { get; set; }
       public DbSet<Players> Players { get; set; }
       public DbSet<Trainers> Trainers { get; set; }
       public DbSet<Matches> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Matches and Teams for HomeTeam
            modelBuilder.Entity<Matches>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.MatchesAsHome)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship between Matches and Teams for GuestTeam
            modelBuilder.Entity<Matches>()
                .HasOne(m => m.GuestTeam)
                .WithMany(t => t.MatchesAsGuest)
                .HasForeignKey(m => m.GuestTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship between Teams and Players
            modelBuilder.Entity<Players>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship between Teams and Trainers
            modelBuilder.Entity<Trainers>()
                .HasOne(t => t.Team)
                .WithMany(t => t.Trainers)
                .HasForeignKey(t => t.TeamsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
