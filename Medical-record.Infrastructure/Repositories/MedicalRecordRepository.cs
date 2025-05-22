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
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDb _context;

        public MedicalRecordRepository(ApplicationDb context) {
            _context = context;
        }
        public async Task<List<MedicalRecord>> GetAllWithPatientsAsync()
        {
            return await _context.MedicalRecords
                          .Include(m => m.Patient)
                          .ToListAsync();
        }

        public async Task<MedicalRecord> GetByRecordIdWithPatientAsync(int recordId)
        {
            return await _context.MedicalRecords
       .Include(r => r.Patient)
       .FirstOrDefaultAsync(r => r.RecordId == recordId);
        }

        public async Task<MedicalRecord?> GetMedicalRecordWithPatientAsync(int recordId)
        {
            return await _context.MedicalRecords
                .Include(m => m.Patient) // 👈 lấy thông tin bệnh nhân
                .FirstOrDefaultAsync(m => m.RecordId == recordId);
        }

    }
}
