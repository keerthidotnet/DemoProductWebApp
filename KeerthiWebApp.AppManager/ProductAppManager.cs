using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeerthiWebApp.Contracts;
using KeerthiWebApp.DTO;
using KeerthiWebApp.DAL;
using AutoMapper;

namespace KeerthiWebApp.AppManager
{
    public class ProductAppManager : ICRUDOperations<ProductDTO>
    {
        IKeerthiCon kfactory = new KInterfaceFactory();
        ProductDAL productDAL = new ProductDAL();

        public ProductDTO Create(ProductDTO createDTO)
        {
            ProductDTO returnDTO = new ProductDTO();
            Product productEntity = new Product();

            var config1 = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
            });

            IMapper mapper1 = config1.CreateMapper();

            productEntity = productDAL.Create(mapper1.Map<ProductDTO, Product>(createDTO));

            var config2 = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product,ProductDTO>();
            });

            IMapper mapper2 = config2.CreateMapper();

            returnDTO = mapper2.Map<Product,ProductDTO>(productEntity);
            return returnDTO;
        }

        public bool Delete(int id)
        {
            return productDAL.Delete(id);
        }

        public ProductDTO Get(int id)
        {
            ProductDTO productDTO = new ProductDTO();

            Product productEntity = productDAL.Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<Product, ProductDTO>(productEntity);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            List<ProductDTO> productsDTO = new List<ProductDTO>();

            IEnumerable<Product> productsEntity = productDAL.GetAll();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product,ProductDTO>();
            });

            IMapper mapper = config.CreateMapper();

            foreach (Product item in productsEntity)
            {
                productsDTO.Add(mapper.Map<Product, ProductDTO>(item));
            }

            return productsDTO;
        }

        public bool Update(ProductDTO updateDTO)
        {
            ProductDTO returnDTO = new ProductDTO();
            Product productEntity = new Product();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
            });

            IMapper mapper = config.CreateMapper();

            return productDAL.Update(mapper.Map<ProductDTO, Product>(updateDTO));
        }
    }
}
