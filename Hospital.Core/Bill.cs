using Hospital.Core.Identity;

namespace Hospital.Core
{
    public class Bill:BaseModel
    {
        public int BillNumber { get; set; }
        public AppUser Patient { get; set; }
        public Insurance Insurance { get; set; }
        public decimal DoctorCharcge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoOfDays { get; set; }
        public decimal NursingCharge { get; set; }
        public decimal LabCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }
     
    }
}