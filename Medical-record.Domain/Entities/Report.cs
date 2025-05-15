using System;
using System.Collections.Generic;

namespace Medical_record.Domain.Entities;


public partial class Report
{
    public int ReportId { get; set; } 

    public string? ReportType { get; set; }

    public DateOnly? GeneratedDate { get; set; }

    public string? Data { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
