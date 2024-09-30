using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceManagement
{
    public class PaymentProcessor : IOrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing payment for order with total: {order.Total}");
        }

        public void CancelOrder(Order order)
        {
            Console.WriteLine("Payment has been canceled.");
        }
    }

}
