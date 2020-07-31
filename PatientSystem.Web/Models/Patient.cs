using System.ComponentModel.DataAnnotations;

namespace PatientSystem.Web.Models
{
    public class Patient
    {
        [Required(ErrorMessage ="Name is Required"), RegularExpression("[a-zA-z]*", ErrorMessage = "Invalid Name: Only alphabets are allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is Required"), RegularExpression("[a-zA-z]*", ErrorMessage = "Invalid Surname: Only alphabets are allowed")]
        public string SurName { get; set; }
        
        public string DOB { get; set; }
        
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }
    }
}
