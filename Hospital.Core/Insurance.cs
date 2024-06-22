using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class Insurance:BaseModel
    {
        public string PolicyNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public ICollection<Bill>Bills { get; set; }
    }
}
