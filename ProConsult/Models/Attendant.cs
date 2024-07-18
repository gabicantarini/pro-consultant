using ProConsult.Data;

namespace ProConsult.Models
{
    public class Attendant : ApplicationUser // Inherits all properties from Identity user
    {
        public string Name { get; set; } = null!;
    }
}
