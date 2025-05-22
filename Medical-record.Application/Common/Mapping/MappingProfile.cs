using AutoMapper;
using Medical_record.Application.DTOs;
using Medical_record.Domain.Entities;
namespace Medical_record.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 

        CreateMap<Patient,PatientVM>().ReverseMap();
        CreateMap<MedicalRecord,MedicalRecordVM>().ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordVM>()
    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
    .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.Patient.BloodType));
            //.ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.Patient.BloodType));
            CreateMap<MedicalRecordVM, MedicalRecord>()
            .ForMember(dest => dest.Patient, opt => opt.Ignore());


        CreateMap<Employee, DoctorVM>().ReverseMap();
        CreateMap<Appointment, AppointmentVM>().ReverseMap();
            CreateMap<PhieuKhamBenh, DoctorVisitVM>().ReverseMap();
            CreateMap<PhieuKhamBenh, DoctorVisitVM>()
                    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Employee.Name))
                    .ForMember(dest => dest.DoctorSpecial, opt => opt.MapFrom(src => src.Employee.Specialty));



            CreateMap<Appointment, AppointmentVM>()
   .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
   .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
   .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Employee.Specialty));
        }
    }
}
