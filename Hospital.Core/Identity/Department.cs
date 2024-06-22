using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Identity
{
    public class Department:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<AppUser>Employess { get; set; }
    }
}
