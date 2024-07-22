using Microsoft.EntityFrameworkCore;
using ProConsult.Data;
using ProConsult.Models;

namespace ProConsult.Repositories.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var appointment = await GetByIdAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context
                .Appointments
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context
                .Appointments
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<List<AgendamentosAnuais>?> GetReportAsync()
        //{
        //    var result = _context.Database.SqlQuery<AgendamentosAnuais>
        //        ($"SELECT MONTH(DataConsulta) AS Mes, COUNT(*) AS QuantidadeAgendamentos FROM Agendamentos WHERE YEAR(DataConsulta) = {DateTime.Today.Year} GROUP BY MONTH(DataConsulta) ORDER BY Mes;");

        //    return await Task.FromResult(result.ToList());
        //}
    }
}
