using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.DTOs
{
    public class MedicalRecordVM
    {
        public int RecordId { get; set; }

        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public DateOnly? AdmissionDate { get; set; }

        public DateOnly? DischargeDate { get; set; }

        public string? Department { get; set; }

        public string? Room { get; set; }

        public string? Diagnosis { get; set; }

        public string? Treatment { get; set; }
        public bool? Sex { get; set; }
        public string? BloodType { get; set; } = "null";
    }
}
