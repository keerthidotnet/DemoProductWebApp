using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeerthiWebApp.DTO;

namespace KeerthiWebApp.Contracts
{
    public interface IKeerthiCon
    {
        ICRUDOperations<ProductDTO> ProductAppManager();
    }
}
