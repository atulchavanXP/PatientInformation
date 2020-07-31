using Microsoft.Extensions.Logging;
using PatientSystem.Domain.Mappings;
using PatientSystem.Domain.Models;
using PatientSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientSystem.Domain.Handlers
{
    public interface IStateHandler
    {
        IEnumerable<State> GetStates();
    }

    public class StateHandler : IStateHandler
    {
        private readonly IStateRepository _stateRepository;
        private readonly ILogger<StateHandler> _logger;

        public StateHandler(IStateRepository stateRepository,
            ILogger<StateHandler> logger)
        {
            _stateRepository = stateRepository;
            _logger = logger;
        }

        public IEnumerable<State> GetStates()
        {
            IEnumerable<State> states = new List<State>();
            try
            {
                var stateList = _stateRepository.GetStates();
                states = stateList.Select(s => s.ToDomain());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return states;
        }
    }
}
