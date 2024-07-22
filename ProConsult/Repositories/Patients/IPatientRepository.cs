using ProConsult.Models;

namespace ProConsult.Repositories.Patients
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Patient?> GetByIdAsync(int id);

    }
}
