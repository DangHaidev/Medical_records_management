using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using Medical_record.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Medical_record.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDb _context;
        private readonly DbSet<Patient> _dbSet;

        public PatientRepository(ApplicationDb context)
        {
            _context = context;
            _dbSet = _context.Set<Patient>();
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task UpdateAsync(int patientId, Patient model)
        {
            var entity = await _dbSet.FindAsync(patientId);
            if (entity == null)
                throw new Exception("Không tìm thấy hồ sơ");        
        }
    }
}
