using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.DTOs
{
    public class DoctorVisitVM
    {
        public int Id { get; set; }
        public int? RecordId { get; set; }

        public int? EmployeeId { get; set; }

        public DateOnly? Date { get; set; }

        public string? DoctorName { get; set; }

        public string? DoctorSpecial {  get; set; }
    }
}
