using Microsoft.Extensions.Logging;
using PatientSystem.Domain.Mappings;
using PatientSystem.Domain.Models;
using PatientSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientSystem.Domain.Handlers
{
    public interface IPatientHandler
    {
        IEnumerable<Patient> GetPatients();
        void SavePatient(IEnumerable<Patient> patientList);
        bool IsExistingPatient(Patient patient);
    }

    public class PatientHandler : IPatientHandler
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientHandler> _logger;

        public PatientHandler(IPatientRepository patientRepository,
            ILogger<PatientHandler> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public IEnumerable<Patient> GetPatients()
        {
            IEnumerable<Patient> patients = new List<Patient>();
            try
            {
                var patientList = _patientRepository.GetPatients();
                patients = patientList.Select(p => p.ToDomain());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }

            return patients;
        }

        public bool IsExistingPatient(Patient patient)
        {
            try
            {
                var patientList = _patientRepository.GetPatients();
                var repoPatient = patientList
                    .Where(p =>
                    p.Name.Equals(patient.Name) &&
                    p.Gender.Equals(patient.Gender) &&
                    p.SurName.Equals(patient.SurName) &&
                    p.DOB.ToShortDateString().Equals(patient.DOB.ToShortDateString())).FirstOrDefault();

                var domainPatient = repoPatient?.ToDomain();
                if (domainPatient != null)
                    return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }

            return false;
        }

        public void SavePatient(IEnumerable<Patient> patientList)
        {
            try
            {
                var patients = patientList.Select(p => p.ToRepo());
                _patientRepository.SavePatient(patients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }
    }
}
