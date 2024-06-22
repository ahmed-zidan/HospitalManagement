using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core
{
    public class Room:BaseModel
    {
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        [ForeignKey("Hospital")]
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }
    }
}