using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsult.Models;
using ProConsult.Repositories.Doctors;
using System.Threading.Tasks;

namespace ProConsult.Components.Pages.Doctors
{
    public class IndexDoctorPage : ComponentBase
    {
        [Inject]
        public IDoctorRepository Repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Doctor> Doctors { get; set; } = new();

        public bool HideButtons { get; set; }

        public async Task DeleteDoctorAsync(Doctor doctor)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Atenção",
                    $"Deseja excluir o medico {doctor.Name}?",
                    yesText: "SIM",
                    cancelText: "NÃO"
                );

                if (result is true)
                {
                    await Repository.DeleteByIdAsync(doctor.Id);
                    Snackbar.Add($"Doctor {doctor.Name} successfully removed!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }
        public void GoToUpdate(int id)
        => NavigationManager.NavigateTo($"/doctors/update/{id}");      


        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Attendant");

            Doctors = await Repository.GetAllAsync();
        }
    }
}
