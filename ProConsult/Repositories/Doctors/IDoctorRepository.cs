using MudBlazor;
using ProConsult.Models;

namespace ProConsult.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor medico);
        Task UpdateAsync(Doctor medico);
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
    }
}
