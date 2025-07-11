﻿using Medical_record.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Domain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<List<MedicalRecord>> GetAllWithPatientsAsync();

    }
}
