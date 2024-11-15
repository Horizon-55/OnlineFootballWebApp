using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FootballWebProject.Models
{
    public class Teams
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Поле Ім'я команди є обов'язковим")]
        public string Name { get; set; }
        public ICollection<Players> Players { get; set; }
        public ICollection<Trainers> Trainers { get; set; }
        public ICollection<Matches> MatchesAsGuest { get; set; }
        public ICollection<Matches> MatchesAsHome { get; set; }
    }
}
