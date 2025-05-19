using Medical_record.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Interfaces
{
    public interface IPatientRepository 
    {
        Task<List<Patient>> GetAllPatientsAsync();

        Task UpdateAsync(int id, Patient model);
        Task<int> GetPatientIdByCCCDAsync(string CCCD);

    }
}
