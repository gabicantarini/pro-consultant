using ProConsult.Models;

namespace ProConsult.Repositories.Appointments
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        Task DeleteByIdAsync(int id);
        Task<Appointment?> GetByIdAsync(int id);
        //Task<List<Appointment>?> GetReportAsync();
    }
}
