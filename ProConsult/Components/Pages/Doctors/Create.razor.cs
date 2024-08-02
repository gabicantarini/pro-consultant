using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Extensions;
using ProConsult.Models;
using ProConsult.Repositories.Doctors;
using ProConsult.Repositories.Specialities;

namespace ProConsult.Components.Pages.Doctors
{
    public class CreateDoctorPage : ComponentBase
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

        public DoctorInputModel InputModel { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is DoctorInputModel model)
                {
                    var doctor = new Doctor
                    {
                        Name = model.Name,
                        Document = model.Document.OnlyCharacters(),
                        Mobile = model.Mobile.OnlyCharacters(),
                        Crm = model.Crm.OnlyCharacters(),
                        SpecialistId = model.SpecialistId,
                        RegisterDate = model.RegisterDate
                    };

                    await repository.AddAsync(doctor);
                    Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/doctors");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Specialist = await SpecialistRepository.GetAllAsync();
        }

    }
}

