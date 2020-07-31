using System.Collections.Generic;
using iMedOneDB.Models;
using DBContext = iMedOneDB.DBContext;

namespace PatientSystem.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<TBLPATIENT> GetPatients();
        void SavePatient(IEnumerable<TBLPATIENT> patientList); 
    }

    public class PatientRepository : IPatientRepository
    {
        public IEnumerable<TBLPATIENT> GetPatients()
        {
            var patients = DBContext.GetData<TBLPATIENT>();
            return patients;
        }

        public void SavePatient(IEnumerable<TBLPATIENT> patientList)
        {
            DBContext.SaveAll(patientList);
        }
    }
}
