namespace EmployeeRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employeeArray = new Employee[3];
            int choice, CurrentArrayIndex = 0;
            bool exit = false;

            while (!exit)
            {

                Console.WriteLine("\nMenu\n\n1.Add Employee\n2.Update Employee\n3.Delete Employee\n4.List Employee\n5.Exit\n");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if (CurrentArrayIndex >= employeeArray.Length)
                        {
                            Console.WriteLine("No space in array");
                            break;
                        }
                        else
                        {
                            Employee emp = new Employee();
                            Console.Write("\nEnter Employee ID : ");
                            emp.Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Employee Name : ");
                            emp.EmployeeName = Console.ReadLine();

                            Console.Write("Enter Employee Gender : ");
                            emp.Gender = Console.ReadLine();

                            employeeArray[CurrentArrayIndex] = emp;
                            Console.WriteLine("Employee added successfully");

                            CurrentArrayIndex++;

                            break;
                        }

                    case 2:
                        Console.Write("\nEnter the employee id to update : ");
                        int inputId = Convert.ToInt32(Console.ReadLine());
                        bool updateIdFound = false;

                        for (int i = 0; i < CurrentArrayIndex; i++)
                        {
                            if (employeeArray[i].Id == inputId)
                            {
                                updateIdFound = true;
                                Console.Write("Enter New Employee Name : ");
                                employeeArray[i].EmployeeName = Console.ReadLine();

                                Console.Write("Enter new Employee Gender : ");
                                employeeArray[i].Gender = Console.ReadLine();
                                Console.WriteLine("Employee Updated successfully");
                            }
                        }
                        if (!updateIdFound)
                        {
                            Console.WriteLine("\nId not found");
                        }
                        break;


                    case 3:
                        Console.Write("\nEnter id of employee to delete : ");
                        int deleteInputId = Convert.ToInt32(Console.ReadLine());
                        bool idFound = false;
                        for (int i = 0; i <= CurrentArrayIndex; i++)
                        {
                            if (employeeArray[i].Id == deleteInputId)
                            {
                                idFound = true;
                                for (int j = i; j < CurrentArrayIndex; j++)
                                {
                                    employeeArray[j] = employeeArray[j + 1];
                                }
                                employeeArray[CurrentArrayIndex - 1] = null;
                                CurrentArrayIndex--;
                                Console.WriteLine("\nEmployee deleted successfully");

                            }
                        }
                        if (!idFound)
                        {
                            Console.WriteLine("\nId not found");
                        }
                        break;

                    case 4:
                        if (CurrentArrayIndex == 0)
                        {
                            Console.WriteLine("\nNo Employee details found");
                            break;
                        }
                        Console.WriteLine("\nAll employee details are :");

                        for (int i = 0; i < CurrentArrayIndex; i++)
                        {
                            Console.Write("\nEmployee id : " + employeeArray[i].Id);
                            Console.Write("\nEmployee Name : " + employeeArray[i].EmployeeName);
                            Console.Write("\nEmployee Gender : " + employeeArray[i].Gender + "\n");

                        }
                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice");
                        break;


                }

            }
        }
    }
}