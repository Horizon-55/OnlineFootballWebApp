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
                .HasForeignKey(g => g.TeamID);
        }
    }
}
