using System.Text.Json;

namespace ParsingJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Employees.json";


            string jsonString = File.ReadAllText(filePath);
            JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
            JsonElement root = jsonDoc.RootElement;

            var employees = root.GetProperty("Employees").EnumerateArray().Select(e => e.ToString()).ToList();
            var employeeList = JsonSerializer.Deserialize<List<Employee>>(employees.ToString());

            var newEmployee = new Employee
            {
                ID = "E003",
                Name = "Alice Johnson",
                Department = "IT",
                Address = new Address
                {
                    Street = "789 Oak St",
                    City = "Springfield",
                    State = "IL",
                    Zip = "62703"
                },
                Projects = new List<string> { "Project D" }
            };
            employeeList.Add(newEmployee);

            var employeeToUpdate = employeeList.FirstOrDefault(e => e.ID == "E001");
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Address.Street = "321 Maple St";
            }

            employeeList.RemoveAll(e => e.Projects.Count < 2);

            foreach (var employee in employeeList)
            {
                if (!employee.Projects.Contains("Project E"))
                {
                    employee.Projects.Add("Project E");
                }
                employee.Projects = employee.Projects.OrderBy(p => p).ToList();
            }

            var updatedJson = new
            {
                Employees = employeeList
            };
            string updatedJsonString = JsonSerializer.Serialize(updatedJson, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJsonString);

            Console.WriteLine("Employees.json file has been updated.");
        }
    }
}