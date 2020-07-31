using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientSystem.Domain.Handlers;

namespace PatientSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityHandler _cityHandler;

        public CityController(ICityHandler cityHandler) 
        {
            _cityHandler = cityHandler;
        }

        [HttpGet("list")]
        public IEnumerable<Domain.Models.City> Get()
        {
            return _cityHandler.GetCities();
        }

        [HttpGet("list/{stateId}")]
        public IEnumerable<Domain.Models.City> Get(int stateId)
        {
            return _cityHandler.GetCities(stateId);
        }
    }
}