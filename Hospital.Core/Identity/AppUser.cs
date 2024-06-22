using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Identity
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string Specialist{ get; set; }
        public string? PictureUrl{ get; set; }
        public bool IsDoctor { get; set; }
        /*[NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
        */
        /*[ForeignKey("Department")]
        public int DepartmentId { get; set; }*/
        public Department? Department { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
        public ICollection<Timing> Timings { get; set; }
    }
}
