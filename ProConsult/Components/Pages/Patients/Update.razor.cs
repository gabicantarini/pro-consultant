using Microsoft.AspNetCore.Components;
using MudBlazor;
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
        public ISnackbar Snackbar { get; set; } = null!;

    }
}
