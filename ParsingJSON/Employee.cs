using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingJSON
{
    internal class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Address Address { get; set; }
        public List<string> Projects { get; set; }
    }
}
