using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class MedicineReport:BaseModel
    {
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Country { get; set; }
        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
