using AutoMapper;
using Medical_record.Application.DTOs;
using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.Services
{
    public class PhieuKhamBenhService
    {
        private readonly IPhieuKhamBenhRepository _phieuKhamRepository;
        private readonly IGenericRepository<PhieuKhamBenh> _phieuKhamGenRepository;
        private readonly IMapper _mapper;

        public PhieuKhamBenhService(IPhieuKhamBenhRepository patientRepository, IMapper mapper, IGenericRepository<PhieuKhamBenh> phieuKhamGenRepository)
        {
            _phieuKhamRepository = patientRepository;
            _mapper = mapper;
            _phieuKhamGenRepository = phieuKhamGenRepository;
        }

        public async Task<IEnumerable<DoctorVisitVM>> GetAllPhieuKhamAsync(int recordId)
        {
            var phieukhamList = await _phieuKhamRepository.GetByRecordIdAsync(recordId);
            return _mapper.Map<IEnumerable<DoctorVisitVM>>(phieukhamList);
        }

        public async Task<IEnumerable<MedicalRecordVM>> GetAllWithPatientAsync()
        {
            var records = await _phieuKhamRepository.GetAllWithPatientsAsync();
            return _mapper.Map<IEnumerable<MedicalRecordVM>>(records);
        }

        //public async Task<PatientVM> GetPatientByIdAsync(int PatientId)
        //{
        //    var patient = await _patientRepository.GetByIdAsync(PatientId);
        //    return _mapper.Map<PatientVM>(patient);
        //}

        public async Task AddPatientAsync(DoctorVisitVM doctorVM)
        {
            var PhieuKham = _mapper.Map<PhieuKhamBenh>(doctorVM);
            await _phieuKhamGenRepository.AddAsync(PhieuKham);
            await _phieuKhamGenRepository.SaveChangesAsync();
           
        }

        //public async Task UpdatePatientAsync(PatientVM patientVM)
        //{
        //    var existing = await _patientRepository.GetByIdAsync(patientVM.PatientId); // 1. lấy từ DB

        //    if (existing == null)
        //        throw new Exception("Patient not found");

        //    _mapper.Map(patientVM, existing); // 2. Map VÀO entity đang được tracking
        //    _patientRepository.Update(existing); // 3. Gọi update
        //    await _patientRepository.SaveChangesAsync();
        //}



        //public async Task DeletePatientAsync(int PatientId)
        //{
        //    var patient = await _patientRepository.GetByIdAsync(PatientId);
        //    _patientRepository.Delete(patient);
        //    await _patientRepository.SaveChangesAsync();
        //}

        //public async Task<int> FindPatientAsync(string cccd)
        //{
        //    return await _cusPatientRepos.GetPatientIdByCCCDAsync(cccd);
        //}
    }
}
