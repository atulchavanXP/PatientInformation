using Microsoft.AspNetCore.Mvc;
using PatientSystem.Domain.Handlers;
using System.Collections.Generic;

namespace PatientSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateHandler _stateHandler;

        public StateController(IStateHandler stateHandler)
        {
            _stateHandler = stateHandler;
        }

        [HttpGet("list")]
        public IEnumerable<Domain.Models.State> Get()
        {
            return _stateHandler.GetStates();
        }
    }
}