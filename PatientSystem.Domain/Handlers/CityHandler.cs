using Microsoft.Extensions.Logging;
using PatientSystem.Domain.Mappings;
using PatientSystem.Domain.Models;
using PatientSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientSystem.Domain.Handlers
{
    public interface ICityHandler
    {
        IEnumerable<City> GetCities();
        IEnumerable<City> GetCities(int stateId);
        City GetCity(int cityId);
    }

    public class CityHandler : ICityHandler
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CityHandler> _logger;

        public CityHandler(ICityRepository cityRepository,
            ILogger<CityHandler> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public IEnumerable<City> GetCities()
        {
            IEnumerable<City> cities = new List<City>();
            try
            {
                var cityList = _cityRepository.GetCities();
                cities = cityList.Select(s => s.ToDomain());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return cities;
        }

        public IEnumerable<City> GetCities(int stateId)
        {
            IEnumerable<City> cities = new List<City>();
            try
            {
                var cityList = _cityRepository.GetCities(stateId);
                cities = cityList.Select(s => s.ToDomain());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return cities;
        }

        public City GetCity(int cityId)
        {
            City city = new City();
            try
            {
                var cityData = _cityRepository.GetCity(cityId);
                city = cityData.ToDomain();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return city;
        }
    }
}
