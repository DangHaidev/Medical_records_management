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
        }
    }
}
