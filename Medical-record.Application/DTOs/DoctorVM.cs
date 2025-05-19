using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.DTOs
{
    public class DoctorVM
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = null!;

        public string? Role { get; set; }

        public string? Specialty { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Address { get; set; }
    }
}
