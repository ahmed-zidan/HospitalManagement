using Hospital.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Web.Areas.Admin.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalId { get; set; }
        public string? HospitalName { get; set; }
        
    }
}
