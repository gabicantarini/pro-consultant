namespace ProConsult.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Crm { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public string SpecialistId { get; set; } = null!;

        public Specialist Specialist { get; set; } = null!;

        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
    }
}
