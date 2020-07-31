using System;
using AutoMapper;
using D = PatientSystem.Domain.Models;
using W = PatientSystem.Web.Models;

namespace PatientSystem.Web.Mappings
{
    public class PatientMapping : Profile
    {
        public PatientMapping()
        {
            CreateMap<D.Patient, W.Patient>()
                .ForMember(s => s.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(s => s.DOB, opt => opt.MapFrom(src => src.DOB.ToShortDateString()))
                .ForMember(s => s.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(s => s.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForAllOtherMembers(dest => dest.Ignore());

            CreateMap<W.Patient, D.Patient>()
                .ForMember(s => s.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(s => s.DOB, opt => opt.MapFrom(src => Convert.ToDateTime(src.DOB)))
                .ForMember(s => s.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(s => s.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForAllOtherMembers(dest => dest.Ignore());
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

    public static class PatientMappingExtensions
    {
        /// <summary>
        /// map repo model to domain
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static D.Patient ToDomain(this W.Patient source)
        {
            return Mapper.Map<D.Patient>(source);
        }
    }
}
