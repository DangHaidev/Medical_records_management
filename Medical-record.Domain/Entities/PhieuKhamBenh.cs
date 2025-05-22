using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Entities
{
    public class PhieuKhamBenh
    {
        public int Id { get; set; }
        public int? RecordId {  get; set; }

        public int? EmployeeId { get; set; }

        public DateOnly? Date {  get; set; }

        public virtual MedicalRecord? MedicalRecord {  get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
