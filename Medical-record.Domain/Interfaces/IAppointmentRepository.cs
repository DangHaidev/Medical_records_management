using Medical_record.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllWithPatientsAsync();
        Task<IEnumerable<Appointment>> GetByAppointIdAsync(int AppointmentId);

    }
}
