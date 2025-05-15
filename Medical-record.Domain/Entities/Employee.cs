using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;


public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Role { get; set; }

    public string? Specialty { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
