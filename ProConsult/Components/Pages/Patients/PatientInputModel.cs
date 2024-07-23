using System.ComponentModel.DataAnnotations;

namespace ProConsult.Components.Pages.Patients
{
    public class PatientInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Documento deve ser fornecido")]
        public string Document { get; set; }

        [Required(ErrorMessage = "E-mail deve ser fornecido")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Celular deve ser fornecido")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Data de nascimento deve ser fornecida")]
        public DateTime BirthDate { get; set; } = DateTime.Today;
    }
}
