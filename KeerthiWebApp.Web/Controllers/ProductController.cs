using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeerthiWebApp.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var prodwebApi = new ProductAPIController();
            IEnumerable<DTO.ProductDTO> modeldata = prodwebApi.Get();
            return View(modeldata);
        }


    }
}