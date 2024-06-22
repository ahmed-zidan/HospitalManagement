using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IHospitalRepo _hospitalRepo { get;}
        public IRoomRepo _roomRepo { get;}
        public IContactRepo _contactRepo {  get;}
        Task<bool> saveChangesAsync();
    }
}
