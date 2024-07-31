using System.ComponentModel.DataAnnotations;

namespace ProConsult.Components.Pages.Doctors
{
    public class DoctorInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Document { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Crm { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Mobile { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public string SpecialistId { get; set; } = null!;

        //public Specialist Specialist { get; set; } = null!;

        //public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
    }
}
