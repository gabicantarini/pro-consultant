namespace ProConsult.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Document { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public DateTime BirthDate { get; set; }

        //public ICollection<Appointment> MyProperty { get; set; } = new List<Appointment>()
    }
}
