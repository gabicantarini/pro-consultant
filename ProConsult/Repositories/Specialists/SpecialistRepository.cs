using Microsoft.EntityFrameworkCore;
using ProConsult.Data;
using ProConsult.Models;

namespace ProConsult.Repositories.Specialities
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Specialist>> GetAllAsync()
        {
            return await _context
                .Specialists
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
