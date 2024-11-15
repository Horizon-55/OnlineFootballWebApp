using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballWebProject.Models;
namespace FootballWebProject.Models
{
    public class Matches
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле дата є обов'язковим для введення!")]
        public DateTime Date { get; set; }

        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }
        public Teams GuestTeam { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public Teams HomeTeam { get; set; }

        [Required(ErrorMessage = "Поле рахунок для гостьової команди є обов'язковим для введення!")]
        public int GuestScore { get; set; }

        [Required(ErrorMessage = "Поле рахунок для домашньої команди є обов'язковим для введення!")]
        public int HomeScore { get; set; }
    }
}
