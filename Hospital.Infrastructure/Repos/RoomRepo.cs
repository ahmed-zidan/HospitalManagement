using Hospital.Core;
using Hospital.Core.Interfaces;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Repos
{
    public class RoomRepo : IRoomRepo
    {
        private readonly AppDbContext _appDbContext;
        public RoomRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Room hospital)
        {
           await _appDbContext.Rooms.AddAsync(hospital);
        }

        public void Delete(Room hospital)
        {
            _appDbContext.Rooms.Remove(hospital);
        }

        public async Task<List<Room>> GetAll(int pageNumber, int pageSize)
        {
            return await _appDbContext.Rooms.Include(x=>x.Hospital).Skip((pageNumber * pageSize) - pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _appDbContext.Rooms.Include(x => x.Hospital).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> totalAsync()
        {
            return await _appDbContext.Rooms.CountAsync();
        }

        public void Update(Room hospital)
        {
            _appDbContext.Rooms.Update(hospital);
        }
    }
}
