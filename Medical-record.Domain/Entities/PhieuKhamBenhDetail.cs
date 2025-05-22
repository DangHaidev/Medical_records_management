using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Entities
{
    public class PhieuKhamBenhDetail
    {
        public int Id { get; set; }

        public int? PhieuKhamId { get; set; }

        public DateTime? DateTime { get; set; }

        public string? Description { get; set; }

        public virtual PhieuKhamBenh? PhieuKhamBenh { get; set; }


    }
}
