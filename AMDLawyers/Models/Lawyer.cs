namespace AMDLawyers.Models
{
    public class Lawyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Crm { get; set; }
        public string Mobile { get; set; }
        public DateTime RegiterDate { get; set; }
        public string SpecialistId { get; set; }

        //public Specialist Specialist { get; set; }

        //public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        //public ICollection<LawSuit> LawSuit { get; set; } = new List<LawSuit>();

    }
}
