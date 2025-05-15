using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;

public partial class Patient
{
    public int PatientId { get; set; }
    public string CCCD { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }
    
    public DateOnly? BirthDate { get; set; }

    public string? Phone { get; set; }

    public string? Photo { get; set; }
    public bool Sex { get; set; }
    public string? BloodType { get; set; }
    public DateOnly? FeePayment { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}
