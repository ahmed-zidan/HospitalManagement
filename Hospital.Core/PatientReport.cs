using Hospital.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class PatientReport:BaseModel
    {
        public string Diagnose { get; set; }
        public string MedicineName { get; set; }
        public AppUser Patient { get; set; }
        public AppUser Doctor { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
