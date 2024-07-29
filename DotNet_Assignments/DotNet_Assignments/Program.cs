using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNet_Assignments
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Email;

        public Employee()
        {
            Id = Id;
            Name = Name;
            Email = Email;
        }
        public void AddEmployee(int id, string name , string email)
        {
            Employee employee = new Employee() { Id = id, Name = name, Email = email };
            employelist.Add(employee);
            Console.WriteLine("Employee added successfully");
        }
        public void GetEmployeeList()
        {
            if employelist.Count > 0)
            {
                foreach (var emp in employelist)
                {
                    Console.Write("Employee ID: " + emp.Id+"\t");
                    Console.Write("Employee Name: " + emp.Name + "\t");
                    Console.Write("Employee Email: " + emp.Email);

                }
                    
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            static List<Employee> employelist = new List<Employee>();
            Console.WriteLine("");
            Public 

        }
    }
}