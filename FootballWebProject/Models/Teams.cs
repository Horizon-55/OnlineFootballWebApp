using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FootballWebProject.Models
{
    public class Teams
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; } // Assuming this is a path or URL to the logo
        public string Information { get; set; }
        public ICollection<Players> Players { get; set; }
        public ICollection<Trainers> Trainers { get; set; }
        public ICollection<Matches> MatchesGuest { get; set; }
        public ICollection<Matches> MatchesHome { get; set; }
    }
}
