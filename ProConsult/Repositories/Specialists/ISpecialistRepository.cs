using ProConsult.Models;

namespace ProConsult.Repositories.Specialities
{
    public interface ISpecialistRepository
    {
        Task<List<Specialist>> GetAllAsync();
    }
}
