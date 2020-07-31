using System;

namespace PatientSystem.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
    }
}
