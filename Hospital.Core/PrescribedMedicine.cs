using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class PrescribedMedicine:BaseModel
    {
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}
