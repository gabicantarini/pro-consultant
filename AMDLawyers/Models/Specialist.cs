namespace AMDLawyers.Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Lawyer> Lawyers { get; set; } = new List<Lawyer>();
    }
}
