using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceManagement
{
    public class Order
    {
        private List<Product> products = new List<Product>();
        public decimal Total { get; private set; }

        public void AddProduct(Product product)
        {
            products.Add(product);
            UpdateTotal();
        }

        public void AddProduct(Product product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                products.Add(product);
            }
            UpdateTotal();
        }

        public void UpdateTotal(decimal discount = 0)
        {
            Total = products.Sum(p => p.Price);
            if (discount > 0)
            {
                Total -= Total * discount;
            }
        }

        public override string ToString()
        {
            var productsStr = string.Join(", ", products.Select(p => p.Name));
            return $"Order(Products: [{productsStr}], Total: {Total})";
        }
    }
}