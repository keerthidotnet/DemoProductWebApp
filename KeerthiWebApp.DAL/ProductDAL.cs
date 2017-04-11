using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeerthiWebApp.Contracts;
using KeerthiWebApp.DTO;
using System.Data.Entity;

namespace KeerthiWebApp.DAL
{
    public class ProductDAL : ICRUDOperations<Product>
    {
        KeerthiEntities ProductDB = new KeerthiEntities();

        public IEnumerable<Product> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return ProductDB.Products;
        }

        public Product Get(int id)
        {
            // TO DO : Code to find a record in database
            return ProductDB.Products.Find(id);
        }

        public Product Create(Product createDTO)
        {
            if (createDTO == null)
            {
                throw new ArgumentNullException("createerror");
            }

            // TO DO : Code to save record into database
            ProductDB.Products.Add(createDTO);
            ProductDB.SaveChanges();
            return createDTO;
        }


        public bool Update(Product updateDTO)
        {
            if (updateDTO == null)
            {
                throw new ArgumentNullException("updateerror");
            }

            // TO DO : Code to update record into database
            ProductDB.Products.Attach(updateDTO);
            ProductDB.Entry(updateDTO).State = EntityState.Modified;
            ProductDB.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Product product = ProductDB.Products.Find(id);
            ProductDB.Products.Remove(product);
            ProductDB.SaveChanges();
            return true;
        }
    }
}
