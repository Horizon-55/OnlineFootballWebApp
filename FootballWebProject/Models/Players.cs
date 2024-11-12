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
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Number { get; set; }
        [ForeignKey("Teams")]
        public int TeamID { get; set; }
        public Teams Team { get; set; }
    }
}
