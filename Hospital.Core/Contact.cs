using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core
{
    public class Contact:BaseModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }

    }
}