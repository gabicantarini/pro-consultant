using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Models;
using ProConsult.Repositories.Appointments;
using ProConsult.Repositories.Doctors;
using ProConsult.Repositories.Patients;

namespace ProConsult.Components.Pages.Appointments
{
    public class CreateAppointmentPage : ComponentBase
    {
        [Inject]
        private IAppointmentRepository AppointmentRepository { get; set; } = null!;

        [Inject]
        private IDoctorRepository DoctorRepository { get; set; } = null!;

        [Inject]
        private IPatientRepository PatientRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        public AppointmentInputModel InputModel { get; set; } = new();
        public List<Doctor> Doctors { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();

        public TimeSpan? time = new TimeSpan(09, 00, 00);
        public DateTime? date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AppointmentInputModel model)
                {
                    var appointment = new Appointment
                    {
                        Note = model.Note,
                        PatientId = model.PatientId,
                        DoctorId = model.DoctorId,
                        AppointmentHour = time!.Value,
                        AppointmentDate = date!.Value
                    };

                    await AppointmentRepository.AddAsync(appointment);
                    Snackbar.Add("Agendamento realizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/appointments");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Doctors = await DoctorRepository.GetAllAsync();
            Patients = await PatientRepository.GetAllAsync();
        }
    }
}
