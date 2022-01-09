using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Presentation
{
    public class Record // central notion: a doctor has many records, a patient has many records, a ward has many records. 
    {
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int DepartmentID { get; set; }
        public int WardID { get; set; }
        public DateTime HospitalizationDate { get; set; } = new(default);
        public DateTime DischargeDate { get; set; } = new(default);
        public string? Diagnosis { get; set; }
        public List<Test> Tests { get; set; } = new(); //search, delete, add
        public List<Therapy> Therapies { get; set; } = new(); //search, delete, add

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Record ID {RecordID}, Patient ID {PatientID}, diagnosed with {Diagnosis}, Department ID {DepartmentID}, Doctor ID {DoctorID}, Ward ID {WardID}, hospitalized {HospitalizationDate}, discharged {DischargeDate}");
            builder.Append("\nTests: ");
            foreach (var test in Tests)
                builder.Append(test);
            builder.Append("\nTherapies: ");
            foreach (var therapy in Therapies)
                builder.Append(therapy);
            return builder.ToString();
        }
        //edit
    }
}
