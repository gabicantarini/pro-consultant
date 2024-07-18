﻿namespace ProConsult.Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
