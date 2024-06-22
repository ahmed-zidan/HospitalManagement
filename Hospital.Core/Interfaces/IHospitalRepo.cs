using Hospital.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Interfaces
{
    public interface IHospitalRepo
    {
        Task<List<HospitalInfo>> GetAllAsync(int pageNumber , int pageSize);
        Task<List<SelectListDto>> GetAllNamesAndIdAsync();
        Task<HospitalInfo> GetHospitalByIdAsync(int id);
        void UpdateHospital(HospitalInfo hospital);
        void DeleteHospital(HospitalInfo hospital);
        Task AddHospitalAsync(HospitalInfo hospital);
        Task<int> totalHospitalsAsync();
        
    }
}
