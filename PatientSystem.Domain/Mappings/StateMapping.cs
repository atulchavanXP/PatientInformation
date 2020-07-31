using AutoMapper;
using iMedOneDB.Models;
using PatientSystem.Domain.Models;

namespace PatientSystem.Domain.Mappings
{
    public class StateMapping : Profile
    {
        public StateMapping()
        {
            CreateMap<State, Tblstate>();

            CreateMap<Tblstate, State>();
        }

        public override string ProfileName
        {
            get { return GetType().Name; }
        }
    }

    public static class StateMappingExtensions
    {
        /// <summary>
        /// map repo model to domain
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static State ToDomain(this Tblstate source)
        {
            return Mapper.Map<State>(source);
        }

        /// <summary>
        /// map domain model to repo
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Tblstate ToRepo(this State source)
        {
            return Mapper.Map<Tblstate>(source);
        }
    }
}
