using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;


public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? RecordId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Medication { get; set; }

    public string? Dosage { get; set; }

    public DateOnly? DatePrescribed { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual MedicalRecord? Record { get; set; }
}
