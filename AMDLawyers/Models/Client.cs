namespace AMDLawyers.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime BirthDate { get; set; } 
        public string CPF { get; set; } = null!;

        public string Address { get; set; } = null!;

        //public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        //public ICollection<LawSuit> LawSuit { get; set; } = new List<LawSuit>();
        //public ICollection<Contract> Contract { get; set; } = new List<Contract>();
    }
}
