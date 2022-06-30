namespace MarsRover.API.Models
{
    public class Rover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Landing_Date { get; set; }
        public DateTime Launch_Date { get; set; }
        public string Status { get; set; }
    }
}