namespace DoctorManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoctorManagementSystem system = new DoctorManagementSystem();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n*****Doctor Management System*****");
                    Console.WriteLine("1. Add Doctor");
                    Console.WriteLine("2. Search Doctor by Registration No");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            system.AddDoctor();
                            break;
                        case "2":
                            system.SearchDoctor();
                            break;
                        case "3":
                            Console.WriteLine("Exiting system.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }
    }
}