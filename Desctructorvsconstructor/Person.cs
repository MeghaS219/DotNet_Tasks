using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desctructorvsconstructor
{
    internal class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        ~Person()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"Hello! My name is {Name}";
        }
    }
}
