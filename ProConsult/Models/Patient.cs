namespace ProConsult.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime BirthDate { get; set; }        

        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
    }
}
