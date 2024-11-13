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
     modelBuilder.Entity<Players>()
        .HasOne(g => g.Team)
        .WithMany(c => c.Players)
        .HasForeignKey(g => g.TeamID)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

    modelBuilder.Entity<Trainers>()
        .HasOne(t => t.Team)
        .WithMany(c => c.Trainers)
        .HasForeignKey(t => t.TeamsId)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

    modelBuilder.Entity<Matches>()
        .HasOne(m => m.GuestTeam)
        .WithMany(c => c.MatchesGuest)
        .HasForeignKey(m => m.GuestTeamId)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

    modelBuilder.Entity<Matches>()
        .HasOne(m => m.HomeTeam)
        .WithMany(c => c.MatchesHome)
        .HasForeignKey(m => m.HomeTeamId)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction
        }
    }
}
