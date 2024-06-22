using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Identity
{
    public class Appointment:BaseModel
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public AppUser Doctor{ get; set; }
        public AppUser Patient { get; set; }
    }
}