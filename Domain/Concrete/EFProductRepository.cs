using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EfDbContext context = new EfDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public Product deleteProduct(int productID)
        {
            Product toDelete = context.Products.Find(productID);
            if(toDelete != null)
            {
                context.Products.Remove(toDelete);
                context.SaveChanges();
            }
            return toDelete;
        }


        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product entreeDB = context.Products.Find(product.ProductID);
                if(entreeDB != null)
                {
                    entreeDB.Name = product.Name;
                    entreeDB.Description = product.Description ;
                    entreeDB.Price= product.Price;
                    entreeDB.Category= product.Category;
                    entreeDB.ImageData= product.ImageData;
                    entreeDB.ImageMimeType= product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
    }
}
