using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.BusinessLogic
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public List<Doctor> Doctors { get; set; } = new();
        public List<Ward> Wards { get; set; } = new();

        //public override string ToString() { }
        //search, edit, delete, add
    }
}
