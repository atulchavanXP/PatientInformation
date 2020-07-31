using System.Collections.Generic;
using iMedOneDB.Models;
using DBContext = iMedOneDB.DBContext;

namespace PatientSystem.Repository
{
    public interface IStateRepository
    {
        IEnumerable<Tblstate> GetStates();
    }

    public class StateRepository : IStateRepository
    {
        public IEnumerable<Tblstate> GetStates()
        {
            var states = DBContext.GetData<Tblstate>();
            return states;
        }
    }
}
