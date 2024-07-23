using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsult.Models;
using ProConsult.Repositories.Patients;

namespace ProConsult.Components.Pages.Patients
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPatientRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Patient> Patients { get; set; } = new List<Patient>();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public bool HideButtons { get; set; }

        public async Task DeletePatient(Patient patient)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Atenção",
                    $"Deseja excluir o paciente {patient.Name}?",
                    yesText: "SIM",
                    cancelText: "NÃO"
                );

                if (result is true)
                {
                    await repository.DeleteByIdAsync(patient.Id);
                    Snackbar.Add($"Patient {patient.Name} successfully removed!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/pacientes/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Attendant");

            Patients = await repository.GetAllAsync();
        }
    }
}
