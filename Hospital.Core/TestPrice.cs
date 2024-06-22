using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class TestPrice:BaseModel
    {
        public string TestCode { get; set; }
        public decimal Price { get; set; }
        public Lab Lab { get; set; }
        public Bill Bill { get; set; }
    }
}
