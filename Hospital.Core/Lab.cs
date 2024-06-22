using Hospital.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class Lab:BaseModel
    {
        public string LabNumber { get; set; }
        public AppUser Patient { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int Weight { get; set; }
        public string Height { get; set; }
        public int BloodPreasure { get; set; }
        public int Temprature { get; set; }
        public string TestResult { get; set; }
    }
}
