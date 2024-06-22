using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Interfaces
{
    public interface IContactRepo
    {
        Task<List<Contact>> GetAll(int pageNumber, int pageSize);
        Task<Contact> GetByIdAsync(int id);
        void Update(Contact model);
        void Delete(Contact model);
        Task AddAsync(Contact model);
        Task<int> totalAsync();
    }
}
