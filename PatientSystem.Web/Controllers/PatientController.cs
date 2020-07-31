using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PatientSystem.Domain.Handlers;
using PatientSystem.Web.Mappings;
using PatientSystem.Web.Models;

namespace PatientSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientHandler _patientHandler;

        public PatientController(IPatientHandler patientHandler)
        {
            _patientHandler = patientHandler;
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<Domain.Models.Patient>> Get()
        {
            try
            {
                var patients = _patientHandler.GetPatients();
                return StatusCode(200, patients);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }            
        }

        [HttpPost("add")]
        public ActionResult Add([FromBody]Patient patient)
        {
            var domainPatient = new Domain.Models.Patient
            {
                CityId = patient.CityId,
                SurName = patient.SurName,
                Name = patient.Name,
                Gender = patient.Gender,
                DOB = Convert.ToDateTime(patient.DOB)
            };
            
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Validdation failed");
            }

            if (_patientHandler.IsExistingPatient(domainPatient))
            {
                return StatusCode(400, "Patient data already exists");
            }

            IEnumerable<Domain.Models.Patient> patients = new List<Domain.Models.Patient> { domainPatient };

            try
            {
                _patientHandler.SavePatient(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return CreatedAtAction("Add Patient", new { patient.Name }, patient);
        }
    }
}