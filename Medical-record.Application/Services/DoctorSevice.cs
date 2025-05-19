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
    public class DoctorSevice
    {
        private readonly IGenericRepository<Employee> _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IPatientRepository _cusPatientRepos;

        public DoctorSevice(IGenericRepository<Employee> doctorRepository, IMapper mapper, IEmailSender emailSender,IPatientRepository patientRepository1)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _cusPatientRepos = patientRepository1;
        }

        public async Task<IEnumerable<DoctorVM>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorVM>>(doctors);
        }

        public async Task<DoctorVM> GetDoctorByIdAsync(int EmployeeId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(EmployeeId);
            return _mapper.Map<DoctorVM>(doctor);
        }

        public async Task AddDoctorAsync(DoctorVM DoctorVM)
        {
            var doctor = _mapper.Map<Employee>(DoctorVM);
            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();
            //await _emailSender.SendEmailAsync("dangd408@gmail.com", "Message", "Tạo profile thành công");
        }

        public async Task UpdateDoctorAsync(DoctorVM DoctorVM)
        {
            var existing = await _doctorRepository.GetByIdAsync(DoctorVM.EmployeeId); // 1. lấy từ DB

            if (existing == null)
                throw new Exception("doctor not found");

            _mapper.Map(DoctorVM, existing); // 2. Map VÀO entity đang được tracking
            _doctorRepository.Update(existing); // 3. Gọi update
            await _doctorRepository.SaveChangesAsync();
        }

   

        public async Task DeleteDoctorAsync(int EmployeeId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(EmployeeId);
            _doctorRepository.Delete(doctor);
            await _doctorRepository.SaveChangesAsync();
        }

        public async Task<int> FindPatientAsync(string cccd)
        {
            return await _cusPatientRepos.GetPatientIdByCCCDAsync(cccd);
        }
    }
}
