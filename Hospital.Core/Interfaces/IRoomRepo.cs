using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Interfaces
{
    public interface IRoomRepo
    {
        Task<List<Room>> GetAll(int pageNumber,int pageSize);
        Task<Room> GetByIdAsync(int id);

        void Update(Room model);
        void Delete(Room model);
        Task AddAsync(Room model);
        Task<int> totalAsync();
    }
}
