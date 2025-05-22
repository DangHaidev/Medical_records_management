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
    public class PhieuKhamBenhRepository : IPhieuKhamBenhRepository
    {

        private readonly ApplicationDb _context;
        private readonly DbSet<PhieuKhamBenh> _dbSet;

        public PhieuKhamBenhRepository(ApplicationDb context)
        {
            _context = context;
            _dbSet = _context.Set<PhieuKhamBenh>();
        }
        public async Task<IEnumerable<PhieuKhamBenh>> GetByRecordIdAsync(int recordId)
        {
            return await _dbSet
                .Where(p => p.RecordId == recordId).Include(m => m.Employee)
                .ToListAsync();
        }

        public async Task<List<PhieuKhamBenh>> GetAllWithPatientsAsync()
        {
            return await _context.PhieuKhamBenhs
                          .Include(m => m.RecordId)
                          .ToListAsync();
        }
    }
}
