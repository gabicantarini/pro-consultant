using Microsoft.EntityFrameworkCore;
using MudBlazor;
using ProConsult.Data;
using ProConsult.Models;

namespace ProConsult.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository

    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }

        }

        public async Task DeleteByIdAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            _context.Doctors.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context
                .Doctors
                .Include(x => x.Specialist)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context
                .Doctors
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Doctor medico)
        {
            try
            {
                _context.Update(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }

        }
    }
}
