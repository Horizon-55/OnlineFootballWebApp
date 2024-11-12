using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballWebProject.Models;
namespace FootballWebProject.Models
{
    public class Trainers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        [ForeignKey("Teams")]
        public int TeamsId { get; set; }
        public Teams Team { get; set; }
    }
}
