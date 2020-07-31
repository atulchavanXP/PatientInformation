using System.Collections.Generic;
using System.Linq;
using iMedOneDB.Models;
using DBContext = iMedOneDB.DBContext;

namespace PatientSystem.Repository
{
    public interface ICityRepository
    {
        IEnumerable<Tblcity> GetCities();
        IEnumerable<Tblcity> GetCities(int stateId);
        Tblcity GetCity(int cityId);
    }

    public class CityRepository : ICityRepository
    {
        public IEnumerable<Tblcity> GetCities()
        {
            var cities = DBContext.GetData<Tblcity>();
            return cities;
        }

        public IEnumerable<Tblcity> GetCities(int stateId)
        {
            var cities = DBContext.GetData<Tblcity>().Where(c => c.StateId == stateId);
            return cities;
        }

        public Tblcity GetCity(int cityId)
        {
            var city = DBContext.GetData<Tblcity>(cityId).ToList();
            return city.FirstOrDefault();
        }
    }
}
