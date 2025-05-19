using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;


public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public TimeOnly? AppointmentTime { get; set; } = new TimeOnly();

    public string? AppointmentType { get; set; }

    public string? AppointmentDescription { get; set; }

    public string? Status { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Patient? Patient { get; set; }
}
