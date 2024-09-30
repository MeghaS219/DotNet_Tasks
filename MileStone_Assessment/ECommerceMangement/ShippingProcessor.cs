using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceManagement
{
    public class ShippingProcessor : IOrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Shipping order with total: {order.Total}");
        }

        public void CancelOrder(Order order)
        {
            Console.WriteLine("Shipping has been canceled.");
        }
    }

}