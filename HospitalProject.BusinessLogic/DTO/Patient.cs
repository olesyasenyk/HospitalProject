using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.BusinessLogic
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Patient {PatientID}, {FirstName}, {LastName}, {Gender}, born {BirthDate}, resides at {Address}");
            builder.Append("Medical records:");

            return builder.ToString();
        }
        //edit
        
    }
}
