using Hospital.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Web.Areas.Admin.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public string? HospitalName { get; set; }


    }
}
