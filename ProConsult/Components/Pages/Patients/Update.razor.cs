using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Extensions;
using ProConsult.Models;
using ProConsult.Repositories.Patients;

namespace ProConsult.Components.Pages.Patients
{
    public class UpdatePatient : ComponentBase
    {
        [Parameter]
        public int PatientId { get; set; }

        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public PatientInputModel InputModel { get; set; } = new();
        private Patient? CurrentPatient { get; set; }
        public DateTime? BirthDate { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentPatient = await repository.GetByIdAsync(PatientId);

            if (CurrentPatient is null)
                return;

            InputModel = new PatientInputModel
            {
                Id = CurrentPatient.Id,
                Name = CurrentPatient.Name,
                Mobile = CurrentPatient.Mobile,
                BirthDate = CurrentPatient.BirthDate,
                Mail = CurrentPatient.Mail,
                Document = CurrentPatient.Document,
            };

            BirthDate = CurrentPatient.BirthDate;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PatientInputModel model)
                {
                    CurrentPatient.Name = model.Name;
                    CurrentPatient.Document = model.Document.OnlyCharacters();
                    CurrentPatient.Mobile = model.Mobile.OnlyCharacters();
                    CurrentPatient.Mail = model.Mail;
                    CurrentPatient.BirthDate = CurrentPatient.BirthDate; //.Value;

                    await repository.UpdateAsync(CurrentPatient);

                    Snackbar.Add($"Paciente {CurrentPatient.Name} atualizado com sucesso!", Severity.Success);
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
