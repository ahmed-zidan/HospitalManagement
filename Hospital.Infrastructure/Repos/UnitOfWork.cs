using Hospital.Core.Interfaces;
using Hospital.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IHospitalRepo _hospitalRepo => new HospitalRepo(_context);

        public IRoomRepo _roomRepo => new RoomRepo(_context);
        public IContactRepo _contactRepo => new ContactRepo(_context);

        public async Task<bool> saveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
