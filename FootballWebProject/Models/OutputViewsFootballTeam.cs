namespace FootballWebProject.Models
{
    public class OutputViewsFootballTeam
    {
        public IEnumerable<Matches> Matches { get; set; }
        public IEnumerable<Teams> Teams { get; set; }
        public IEnumerable <Players> Players { get; set; }
        public IEnumerable<Trainers> Trainers { get; set; }
    }
}
