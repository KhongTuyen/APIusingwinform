using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rest_API.Models;
namespace Rest_API.Controllers
{
   
    public class ProductController : ApiController
    {
        TuyenDBEntities1 db = new TuyenDBEntities1(); 
        

        [HttpGet]   
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> query = db.Products;
            return query;
        }
        [HttpPost]
 
        public bool AddProduct(int id , string name , int price , int quantity)
        {
            Product sp = db.Products.FirstOrDefault(x => x.ID == id);
            if(sp == null)
            {
                Product newsp = new Product();
                newsp.ID = id;
                newsp.Name = name;
                newsp.Price = price;
                newsp.Quantity = quantity;
                db.Products.Add(newsp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool Edit(int id, string name, int price, int quantity)
        {
            Product sp = db.Products.FirstOrDefault(x => x.ID == id);
            if (sp != null)
            {
               
               /* sp.ID = id;*/
                sp.Name = name;
                sp.Price = price;
                sp.Quantity = quantity;              
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            Product sp = db.Products.FirstOrDefault(x => x.ID == id);
            if(sp != null)
            {
                db.Products.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
