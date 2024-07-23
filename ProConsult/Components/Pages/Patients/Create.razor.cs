using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Models;
using ProConsult.Repositories.Patients;

namespace ProConsult.Components.Pages.Patients
{
    public class CreatePatientPage : ComponentBase
    {
        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public PatientInputModel InputModel { get; set; } = new();

        public DateTime? BirthDate { get; set; } = DateTime.Today;

        public DateTime? MaxDate { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PatientInputModel model)
                {
                    var patient = new Patient
                    {
                        Name = model.Name,
                        Document = model.Document,
                        Mobile = model.Mobile,
                        Mail = model.Mail,
                        BirthDate = BirthDate.Value
                    };

                    await repository.AddAsync(patient);
                    Snackbar.Add("Paciente cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/patients");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
