using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Identity
{
    public class Payroll:BaseModel
    {
        public decimal Salary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal BonusSalary { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal Compensation { get; set; }
        public string AccountNumber { get; set; }
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public AppUser Employee { get; set; }
    }
}