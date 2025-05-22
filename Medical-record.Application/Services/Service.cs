using AutoMapper;
using Medical_record.Application.DTOs;
using Medical_record.Domain.Entities;
using Medical_record.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_record.Application.Services
{
	public class Service
	{
        private readonly IGenericRepository<Appointment> _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IAppointmentRepository _appointmentRepository;

        public Service(IGenericRepository<Appointment> serviceRepository, IMapper mapper, IEmailSender emailSender, IAppointmentRepository appointmentRepository )
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _emailSender = emailSender;
           _appointmentRepository = appointmentRepository;
        }

        public async Task AddAppointmentAsync(AppointmentVM appointmentVM)
        {
            var record = _mapper.Map<Appointment>(appointmentVM);
            await _serviceRepository.AddAsync(record);
            await _emailSender.SendEmailAsync(appointmentVM.Email, "Message", "Đặt lịch khám thành công. Thời gian khám là ngày " + appointmentVM.AppointmentDate
                + ". Vào lúc " + appointmentVM.AppointmentTime);
            await _serviceRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppointmentVM>> GetAllWithPatientAsync()
        {
            var records = await _appointmentRepository.GetAllWithPatientsAsync();
            return _mapper.Map<IEnumerable<AppointmentVM>>(records);
        }

        public async Task<IEnumerable<AppointmentVM>> GetAllAppointAsync(int appointId)
        {
            var applist = await _appointmentRepository.GetByAppointIdAsync(appointId);
            return _mapper.Map<IEnumerable<AppointmentVM>>(applist);
        }

    }
}
