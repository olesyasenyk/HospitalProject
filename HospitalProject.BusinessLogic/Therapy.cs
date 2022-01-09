using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.BusinessLogic
{
    public class Therapy
    {
        public int TherapyID { get; set; }
        public string TherapyName { get; set; }
        public DateTime TherapyTime { get; }
        string TherapyComment { get; set; }
        //public override string ToString() { }
        //edit
    }
}
