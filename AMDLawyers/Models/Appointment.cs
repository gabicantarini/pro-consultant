namespace AMDLawyers.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string? Note { get; set; }
        public int ClientId { get; set; }
        public int LawyerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentHour { get; set; }
        public Client Client { get; set; } = null!;
        public Lawyer Lawyer { get; set; } = null!;
    }
}
