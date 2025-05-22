using AutoMapper;
using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Medical_record.Application.DTOs;

namespace Medical_record.Application.Services
{
    //public class PatientService
    //{
    //    private readonly IPatientRepository _patientRepository;

    //    public PatientService(IPatientRepository patientRepository)
    //    {
    //        _patientRepository = patientRepository;
    //    }

    //    public async Task<IEnumerable<Patient>> GetAllPatientAsync()
    //    {
    //        return await _patientRepository.GetAllPatientsAsync();
    //    }
    //}

    public class PatientService
    {
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<MedicalRecord> _medicalRecordRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IPatientRepository _cusPatientRepos;

        public PatientService(IGenericRepository<Patient> patientRepository, IMapper mapper, IEmailSender emailSender,IPatientRepository patientRepository1, IGenericRepository<MedicalRecord> medicalRecordRepository)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _cusPatientRepos = patientRepository1;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<IEnumerable<PatientVM>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientVM>>(patients);
        }

        public async Task<PatientVM> GetPatientByIdAsync(int PatientId)
        {
            var patient = await _patientRepository.GetByIdAsync(PatientId);
            return _mapper.Map<PatientVM>(patient);
        }

        public async Task AddPatientAsync(PatientVM patientVM)
        {
            var patient = _mapper.Map<Patient>(patientVM);
            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
            //await _emailSender.SendEmailAsync("dangd408@gmail.com", "Message", "Tạo profile thành công");
        }

        public async Task UpdatePatientAsync(PatientVM patientVM)
        {
            var existing = await _patientRepository.GetByIdAsync(patientVM.PatientId); // 1. lấy từ DB

            if (existing == null)
                throw new Exception("Patient not found");

            _mapper.Map(patientVM, existing); // 2. Map VÀO entity đang được tracking
            _patientRepository.Update(existing); // 3. Gọi update
            await _patientRepository.SaveChangesAsync();
        }

   

        public async Task DeletePatientAsync(int PatientId)
        {
            var relatedRecords = await _medicalRecordRepository
       .FindAllAsync(r => r.PatientId == PatientId);

            _medicalRecordRepository.DeleteRange(relatedRecords);

            var patient = await _patientRepository.GetByIdAsync(PatientId);
            _patientRepository.Delete(patient);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task<int> FindPatientAsync(string cccd)
        {
            return await _cusPatientRepos.GetPatientIdByCCCDAsync(cccd);
        }

        public async Task<bool> IsCCCDExistedAsync(string cccd)
        {
            var existing = await _patientRepository.FindAsync(p => p.CCCD == cccd);
            return existing != null;
        }


    }
}
