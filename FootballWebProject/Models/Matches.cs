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
        public Teams GuestTeam { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public Teams HomeTeam { get; set; }

        [Required]
        public int GuestScore { get; set; }

        [Required]
        public int HomeScore { get; set; }
    }
}
