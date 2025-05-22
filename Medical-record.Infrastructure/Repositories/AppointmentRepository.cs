using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using Medical_record.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDb _context;

        public AppointmentRepository(ApplicationDb context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllWithPatientsAsync()
        {
            return await _context.Appointments
                          .Include(m => m.Employee).Include(m => m.Patient)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByAppointIdAsync(int AppointmentId)
        {
            return await _context.Appointments
                .Where(p => p.PatientId == AppointmentId).Include(m => m.Employee).Include(m => m.Patient)
                .ToListAsync();
        }
    }
}
