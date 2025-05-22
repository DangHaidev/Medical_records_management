using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Medical_record.Application.DTOs
{
    public class PatientVM
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "CCCD không được để trống")]
        public string CCCD { get; set; } = null!;

        [Required(ErrorMessage = "Tên bệnh nhân không được để trống")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateOnly? BirthDate { get; set; }

        public string? Phone { get; set; }

        public string? Photo { get; set; } = "patient4.png";

        public bool Sex { get; set; }
        public string? BloodType { get; set; } = "null";
        public DateOnly? FeePayment { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public DateOnly? ExpireFee { get
            {
                if(FeePayment == null)
                    return null;
                var date = FeePayment.Value;
                return  date.AddYears(1);
            } }

        public int? Age
        {
            get
            {
                if (BirthDate == null)
                    return null;

                var today = DateOnly.FromDateTime(DateTime.Today);
                int age = today.Year - BirthDate.Value.Year;

                if (BirthDate.Value > today.AddYears(-age))
                    age--;

                return age;
            }
        }
    }
}
