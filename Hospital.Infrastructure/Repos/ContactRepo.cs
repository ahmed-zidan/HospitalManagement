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
    public class ContactRepo : IContactRepo
    {
        private readonly AppDbContext _appDbContext;
        public ContactRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Contact model)
        {
            await _appDbContext.Contacts.AddAsync(model);
        }

        public void Delete(Contact model)
        {
            _appDbContext.Contacts.Remove(model);
        }

        public async Task<List<Contact>> GetAll(int pageNumber, int pageSize)
        {
            return await _appDbContext.Contacts.Include(x=>x.Hospital).Skip((pageNumber * pageSize) - pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _appDbContext.Contacts.Include(x => x.Hospital).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> totalAsync()
        {
            return await _appDbContext.Contacts.CountAsync();
        }

        public void Update(Contact model)
        {
            _appDbContext.Contacts.Update(model);
        }
    }
}
