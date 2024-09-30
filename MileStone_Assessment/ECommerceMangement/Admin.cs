using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerceManagement
{
    public class Admin : Person
    {
        public string AdminLevel { get; set; }

        // Constructor to initialize a new admin
        public Admin(string name, string email, string adminLevel) : base(name, email)
        {
            AdminLevel = adminLevel;
        }

        // Returns a string representation of the admin
        public override string ToString()
        {
            return $"Admin(Name: {Name}, Email: {Email}, Level: {AdminLevel})";
        }
    }
}