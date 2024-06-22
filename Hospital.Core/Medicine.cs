using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class Medicine:BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineReport> MedicineReports { get; set; }
        public ICollection<PrescribedMedicine> prescribedMedicines { get; set; }
    }
}
