using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.DTOs
{
    public class AppointmentVM
    {
        public int AppointmentId { get; set; }

        public int? PatientId { get; set; }

		public int? EmployeeId { get; set; }
		[Required(ErrorMessage = "không được để trống")]

		public DateTime? AppointmentDate { get; set; }
		[Required(ErrorMessage = " không được để trống")]

		public TimeOnly? AppointmentTime { get; set; } = new TimeOnly();

        public string? AppointmentType { get; set; }

        public string? AppointmentDescription { get; set; }

        public string? Status { get; set; } = "0";
        public string? cccd { get; set; } 
		[Required(ErrorMessage = " không được để trống")]

        public string Email { get; set; }   

        public string? EmployeeName { get; set; }

        public string? PatientName { get; set; }
        public string? Specialty { get; set; }

    }
}
