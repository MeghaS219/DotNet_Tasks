using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerceManagement
{
    public class Customer : Person
    {
        public string Username { get; set; }

        // Constructor to initialize a new customer
        public Customer(string name, string email, string username) : base(name, email)
        {
            Username = username;
        }

        // Returns a string representation of the customer
        public override string ToString()
        {
            return $"Customer(Name: {Name}, Email: {Email}, Username: {Username})";
        }
    }
}