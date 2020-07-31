using AutoMapper;
using iMedOneDB.Models;
using PatientSystem.Domain.Models;

namespace PatientSystem.Domain.Mappings
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City, Tblcity>();

            CreateMap<Tblcity, City>();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

    public static class CityMappingExtensions
    {
        /// <summary>
        /// map repo model to domain
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static City ToDomain(this Tblcity source)
        {
            return Mapper.Map<City>(source);
        }

        /// <summary>
        /// map domain model to repo
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Tblcity ToRepo(this City source)
        {
            return Mapper.Map<Tblcity>(source);
        }
    }
}
