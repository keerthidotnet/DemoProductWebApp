using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeerthiWebApp.Contracts;
using KeerthiWebApp.DTO;

namespace KeerthiWebApp.AppManager
{
    public class KInterfaceFactory : IKeerthiCon
    {
        public ICRUDOperations<ProductDTO> ProductAppManager()
        {
            return new ProductAppManager();
        }
    }
}
