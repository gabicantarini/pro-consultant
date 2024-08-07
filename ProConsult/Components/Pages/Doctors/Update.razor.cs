using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsult.Extensions;
using ProConsult.Models;
using ProConsult.Repositories.Doctors;
using ProConsult.Repositories.Specialities;

namespace ProConsult.Components.Pages.Doctors
{
    public class UpdateDoctorPage : ComponentBase
    {
        [Parameter]
        public int DoctorId { get; set; }

        [Inject]
        public IDoctorRepository Repository { get; set; } = null!;

        [Inject]
        private ISpecialistRepository SpecialistRepository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public DoctorInputModel InputModel { get; set; } = new();

        public Doctor? CurrentDoctor { get; set; }

        public List<Specialist> Specialists { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (CurrentDoctor is null) return;

                if (editContext.Model is DoctorInputModel model)
                {
                    CurrentDoctor.Id = DoctorId;
                    CurrentDoctor.Name = model.Name;
                    CurrentDoctor.Document = model.Document.OnlyCharacters();
                    CurrentDoctor.Crm = model.Crm.OnlyCharacters();
                    CurrentDoctor.Mobile = model.Mobile.OnlyCharacters();
                    CurrentDoctor.SpecialistId = model.SpecialistId;

                    await Repository.UpdateAsync(CurrentDoctor);

                    Snackbar.Add($"Doctor {CurrentDoctor.Name} updated!", Severity.Success);
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
            CurrentDoctor = await Repository.GetByIdAsync(DoctorId);
            Specialists = await SpecialistRepository.GetAllAsync();

            if (CurrentDoctor is null)
                return;

            InputModel = new DoctorInputModel
            {
                Crm = CurrentDoctor.Crm,
                Name = CurrentDoctor.Name,
                Mobile = CurrentDoctor.Mobile,
                Document = CurrentDoctor.Document,
                SpecialistId = CurrentDoctor.SpecialistId
            };

        }
    }
}
