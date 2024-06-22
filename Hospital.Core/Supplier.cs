using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class Supplier:BaseModel
    {
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<MedicineReport> MedicineReports { get; set; }

    }
}
