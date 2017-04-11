using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KeerthiWebApp.Contracts;
using KeerthiWebApp.DTO;
using KeerthiWebApp.AppManager;

namespace KeerthiWebApp.Web.Controllers
{
    public class ProductAPIController : ApiController
    {
        static readonly IKeerthiCon prodFac = new KInterfaceFactory();

        public IEnumerable<ProductDTO> Get()
        {
            return prodFac.ProductAppManager().GetAll();
        }

        public ProductDTO Post(ProductDTO prod)
        {
            return prodFac.ProductAppManager().Create(prod);
        }

        public IEnumerable<ProductDTO> Put( ProductDTO product)
        {
            if (prodFac.ProductAppManager().Update(product))
            {
                return prodFac.ProductAppManager().GetAll();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ProductDTO> Delete(int id)
        {
            if (prodFac.ProductAppManager().Delete(id))
            {
                return prodFac.ProductAppManager().GetAll(); ;
            }
            else
            {
                return null;
            }
        }
    }
}
