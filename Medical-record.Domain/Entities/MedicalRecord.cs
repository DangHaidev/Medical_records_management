using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;


public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PatientId { get; set; }

    public DateOnly? AdmissionDate { get; set; }

    public DateOnly? DischargeDate { get; set; }

    public string? Department { get; set; }

    public string? Room { get; set; }

    public string? Diagnosis { get; set; }

    public string? Treatment { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
