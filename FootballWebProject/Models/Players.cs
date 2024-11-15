using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FootballWebProject.Models;
namespace FootballWebProject.Models
{
    public class Players
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле Ім'я є обов'язковим!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле Прізвище є обов'язковим!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле позиція є обов'язковим!")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Поле номер гравця є обов'язковим!")]
        public string Number { get; set; }
        [ForeignKey("Teams")]
        [Required(ErrorMessage = "Поле команда потрібно обрати!")]
        public int TeamID { get; set; }
        public Teams Team { get; set; }
    }
}
