using System.ComponentModel.DataAnnotations;

namespace ProConsult.Components.Pages.Appointments
{
    public class AppointmentInputModel
    {
        [MaxLength(250, ErrorMessage = "The field {0} must have max of {1} caracters")]
        public string? Note { get; set; }

        [Required(ErrorMessage = "{0} requested")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Invalid value")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "{0} requested")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Invalid value")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "{0} requested")]
        public TimeSpan AppointmentHour { get; set; }

        [Required(ErrorMessage = "{0} requested")]
        public DateTime AppointmentDate { get; set; }
    }
}
