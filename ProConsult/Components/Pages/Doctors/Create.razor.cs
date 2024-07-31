using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Models;
using ProConsult.Repositories.Doctors;
using ProConsult.Repositories.Specialities;

namespace ProConsult.Components.Pages.Doctor
{
    public class CreateDoctorsPage : ComponentBase
    {
        [Inject]
        private ISpecialistRepository SpecialistRepository { get; set; } = null!;

        [Inject]
        public IDoctorRepository repository { get; set; } = default!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Specialist> Specialist { get; set; } = new();

        //public DoctorInputModel InputModel { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                //if (editContext.Model is DoctorInputModel model)
                //{
                    
                //}
            }
        }

    }
}

