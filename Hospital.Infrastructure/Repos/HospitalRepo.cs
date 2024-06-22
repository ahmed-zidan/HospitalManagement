using Hospital.Core;
using Hospital.Core.Interfaces;
using Hospital.Core.Models;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Repos
{
    public class HospitalRepo : IHospitalRepo
    {
        private readonly AppDbContext _context;
        public HospitalRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddHospitalAsync(HospitalInfo hospital)
        {
            await _context.HospitalInfo.AddAsync(hospital);
        }

        public void DeleteHospital(HospitalInfo hospital)
        {
            _context.HospitalInfo.Remove(hospital);
        }

        public async Task<List<HospitalInfo>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.HospitalInfo.Skip((pageNumber * pageSize) - pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<SelectListDto>> GetAllNamesAndIdAsync()
        {
            return await _context.HospitalInfo.Select(x=>new SelectListDto{ Name=x.Name , Id=x.Id}).ToListAsync();
        }

        public async Task<HospitalInfo> GetHospitalByIdAsync(int id)
        {
            return await _context.HospitalInfo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> totalHospitalsAsync()
        {
           return await _context.HospitalInfo.CountAsync();
        }

        public void UpdateHospital(HospitalInfo hospital)
        {
            _context.HospitalInfo.Update(hospital);
        }
    }
}
