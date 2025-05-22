using AutoMapper;
using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using Medical_record.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Medical_record.Application.Services
{
    public class MedicalRecordService
    {
        private readonly IGenericRepository<MedicalRecord> _patientRepository;
        private readonly IMapper _mapper;
        private readonly IMedicalRecordRepository _recordRepository;

        public MedicalRecordService(IGenericRepository<MedicalRecord> patientRepository, IMapper mapper, IMedicalRecordRepository recordRepository)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _recordRepository = recordRepository;
        }

        public async Task<IEnumerable<MedicalRecordVM>> GetAllRecordsAsync()
        {
            var records = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicalRecordVM>>(records);
        }

        public async Task<MedicalRecordVM> GetRecordByIdAsync(int PatientId)
        {
            var record = await _recordRepository.GetByRecordIdWithPatientAsync(PatientId);
            return _mapper.Map<MedicalRecordVM>(record);
            //return _mapper.Map<MedicalRecordVM>(record);
        }

        public async Task AddRecordAsync(MedicalRecordVM MedicalRecordVM)
        {
            var record = _mapper.Map<MedicalRecord>(MedicalRecordVM);
            await _patientRepository.AddAsync(record);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task UpdateRecordAsync(MedicalRecordVM MedicalRecordVM)
        {
            var record = _mapper.Map<MedicalRecord>(MedicalRecordVM);
            _patientRepository.Update(record);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task DeleteRecordAsync(int PatientId)
        {
            var record = await _patientRepository.GetByIdAsync(PatientId);
            _patientRepository.Delete(record);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecordVM>> GetAllWithPatientAsync()
        {
           var records = await _recordRepository.GetAllWithPatientsAsync();
            return _mapper.Map<IEnumerable<MedicalRecordVM>>(records);
        }


        public async Task<MedicalRecordVM?> GetMedicalRecordDetailAsync(int recordId)
        {
            var record = await _recordRepository.GetMedicalRecordWithPatientAsync(recordId);
            return _mapper.Map<MedicalRecordVM>(record);
        }

    }
}
