using AutoMapper;
using iMedOneDB.Models;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using PatientSystem.Domain.Handlers;
using PatientSystem.Domain.Mappings;
using PatientSystem.Domain.Models;
using PatientSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientSystem.UnitTest
{
    [TestFixture]
    public class PatientHandlerTest : TestBase
    {
        private IPatientHandler _patientHandler;
        private IPatientRepository _patientRepository;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<PatientMapping>());
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Mapper.Reset();
        }

        [SetUp]
        public void Setup()
        {
            _patientRepository = Substitute.For<IPatientRepository>();
            var logger = Substitute.For<ILogger<PatientHandler>>();
            _patientHandler = new PatientHandler(_patientRepository, logger);
        }

        [Test]
        public void Get_patients_returns_list()
        {
            _patientRepository.GetPatients().Returns(info =>
            {
                List<TBLPATIENT> patients = new List<TBLPATIENT>()
                {
                new TBLPATIENT(),
                new TBLPATIENT(),
                new TBLPATIENT()
                };
                return patients.AsEnumerable();
            });

            var patients = _patientHandler.GetPatients();

            Assert.IsTrue(patients.ToList().Count() > 0);
        }

        [Test]
        public void Save_patients_saves_successfully()
        {
            var patient = CreatePatient1();
            IEnumerable<Patient> patients = new List<Patient> { patient };

            Assert.DoesNotThrow(() =>
            {
                _patientHandler.SavePatient(patients);
            });
        }

        [Test]
        public void Create_duplicate_patients_throws_exception()
        {
            var patient = CreatePatient2();
            IEnumerable<Patient> patients = new List<Patient> { patient };

            Assert.DoesNotThrow(() =>
            {
                _patientHandler.SavePatient(patients);
            });

            //create duplication record
            Assert.Throws<Exception>(() =>
            {
                _patientHandler.SavePatient(patients);
            });
        }
    }
}
