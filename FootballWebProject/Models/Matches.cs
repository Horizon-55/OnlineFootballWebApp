using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballWebProject.Models;
namespace FootballWebProject.Models
{
    public class Matches
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        [Required]
        public int GuestScore { get; set; } //гостьовий рахунок властивість
        [Required]
        public int HomeScore { get; set; } //домашній рахунок властивість
        public Teams GuestTeams { get; set; }
        public Teams HomeTeams { get; set; }
    }
}
