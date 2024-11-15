using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FootballWebProject.Models
{
    public class Trainers
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле Ім'я тренера є обов'язковим")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле Прізвище тренера є обов'язковим")]
        public string Surname { get; set; }
        [ForeignKey("Teams")]
        [Required(ErrorMessage = "Поле обрати команду тренера є обов'язковим")]
        public int TeamsId { get; set; }
        public Teams Team { get; set; }
    }
}
