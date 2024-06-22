using Hospital.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class Timing:BaseModel
    {
        public AppUser Doctor { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public DoctorStatus DoctorStatus { get; set; }
        public int Duration { get; set; }
       
    }
}
