namespace Assignment1_SalaryProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int BasicSalary;
            double GrossSalary, Percent_HRA, Percent_DA;
            while (true)
            {
                Console.WriteLine("Please enter Basic salary");
                if (int.TryParse(Console.ReadLine(), out BasicSalary))
                {
                    if (BasicSalary <= 10000)
                    {
                        Percent_HRA = 0.2;
                        Percent_DA =  0.8;
                    }
                    else if (BasicSalary <= 20000)
                    {
                        Percent_HRA = 0.25;
                        Percent_DA = 0.9;
                    }
                    else

                        Percent_HRA = 0.3;
                        Percent_DA = 0.95;                    
                    GrossSalary = BasicSalary * (1 + Percent_HRA + Percent_DA);
                    Console.WriteLine("Gross Salary is " + GrossSalary);
                }
                else
                    Console.WriteLine("please enter a valid value for Basic salary");
                Console.WriteLine("Do you want another check. Type Yes ore No");
                string Choice = Console.ReadLine();
                if (Choice != "yes")
                {
                    break;
                }
            }
            
        }
    }
}