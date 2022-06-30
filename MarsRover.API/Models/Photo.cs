namespace MarsRover.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public Camera Camera { get; set; }
        public string img_Src { get; set; }
        public DateTime Earth_Date { get; set; }
        public Rover Rover { get; set; }
    }
}