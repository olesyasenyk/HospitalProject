using DA = HospitalProject.DataAccess.DataAccess;

namespace HospitalProject.BusinessLogic
{
    public class BusinessLogic
    {
        public static List<Patient> SearchPatient(string name)
        {
            List<Patient> searchedPatients = new();
            var foundPatients = DA.SearchPatient(name);

            foreach (var foundPatient in foundPatients)
            {
                Patient searchedPatient = new();

                searchedPatient.PatientID = foundPatient.PatientID;//?????????????
                searchedPatient.FirstName = foundPatient.FirstName;
                searchedPatient.LastName = foundPatient.LastName;
                searchedPatient.Gender = foundPatient.Gender;
                searchedPatient.BirthDate = foundPatient.BirthDate;
                searchedPatient.Address = foundPatient.Address;

                searchedPatients.Add(searchedPatient);
            }

            return searchedPatients;
        }

        public static Patient SearchPatient(int id) 
        {         
            Patient searchedPatient = new();
            DataAccess.Patient foundPatient = new();
                 
            foundPatient = DA.SearchPatient(id);

            searchedPatient.PatientID = foundPatient.PatientID;//?????????????
            searchedPatient.FirstName = foundPatient.FirstName;
            searchedPatient.LastName = foundPatient.LastName;
            searchedPatient.Gender = foundPatient.Gender;
            searchedPatient.BirthDate = foundPatient.BirthDate;
            searchedPatient.Address = foundPatient.Address;

            return searchedPatient;           
        }
    }
}
       
    
