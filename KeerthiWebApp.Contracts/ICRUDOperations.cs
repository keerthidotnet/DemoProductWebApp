using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeerthiWebApp.Contracts
{
    public interface ICRUDOperations<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T createDTO);
        bool Update(T updateDTO);
        bool Delete(int id);  
    }
}
