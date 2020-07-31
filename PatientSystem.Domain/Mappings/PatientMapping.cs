using AutoMapper;
using iMedOneDB.Models;
using PatientSystem.Domain.Models;

namespace PatientSystem.Domain.Mappings
{    
    public class PatientMapping : Profile
    {
        public PatientMapping()
        {
            CreateMap<Patient, TBLPATIENT>();

            CreateMap<TBLPATIENT, Patient>();
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
        public static Patient ToDomain(this TBLPATIENT source)
        {
            return Mapper.Map<Patient>(source);
        }

        /// <summary>
        /// map domain model to repo
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TBLPATIENT ToRepo(this Patient source)
        {
            return Mapper.Map<TBLPATIENT>(source);
        }
    }
}
