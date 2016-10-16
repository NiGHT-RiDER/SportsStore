using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * date : 14 octobre 2016
 * auteur : stefan bogdanovic 
 */
namespace Domain.Entities
{

    public class Cart
    {
        private List<CartLine> lignesDeCommande = new List<CartLine>();
        public IEnumerable<CartLine> Lines
        {
            get { return lignesDeCommande; }
        }

        public void AddItem(Product toAdd , int qty)
        {
            CartLine line = lignesDeCommande
                .Where(p => p.Product.ProductID == toAdd.ProductID)
                .FirstOrDefault();
            if(line == null)
            {
                lignesDeCommande.Add(new CartLine
                {
                    Product = toAdd,
                    Quantity = qty
                });
            } 
            else
            {
                line.Quantity += qty;
            }
        }

        public void Clear()
        {
            lignesDeCommande.Clear();
        }


        public decimal ComputeTotalValue()
        {
            return lignesDeCommande.Sum(e => e.Product.Price * e.Quantity);
        }

        public void RemoveLine(Product p)
        {
            lignesDeCommande.RemoveAll(x => x.Product.ProductID == p.ProductID);
        }

    }

    public class CartLine
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
