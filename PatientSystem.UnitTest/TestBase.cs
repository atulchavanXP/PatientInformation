using NUnit.Framework;
using PatientSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSystem.UnitTest
{
    [TestFixture]
    public abstract class TestBase
    {
        protected Patient CreatePatient1()
        {
            Patient patient = new Patient
            {
                CityId = 1,
                DOB = DateTime.Now.AddDays(-10),
                Gender = "M",
                Name = "Atul",
                SurName = "Chavan"
            };
            return patient;
        }

        protected Patient CreatePatient2()
        {
            Patient patient = new Patient
            {
                CityId = 1,
                DOB = DateTime.Now.AddDays(-50),
                Gender = "M",
                Name = "Sachin",
                SurName = "More"
            };
            return patient;
        }
    }
}
