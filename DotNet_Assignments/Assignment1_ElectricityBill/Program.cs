namespace Assignment1_ElectricityBill
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Double BillAmount;
            Double Units;
            while (true)
            {
                Console.WriteLine("Enter tye number of  Units Used");
                if (Double.TryParse(Console.ReadLine(), out Units))
                {
                    if (Units > 250)
                        BillAmount = (Units - 250) * 1.5 + 100 * (1.2 + 0.75) + 50 * 0.5;
                    else if (Units > 150)
                        BillAmount = (Units - 150) * 1.2 + 100 * 0.75 + 50 * 0.5;
                    else if (Units > 50)
                        BillAmount = (Units - 50) * 0.75 + 50 * 0.5;
                    else
                        BillAmount = Units * 0.5;
                    Console.WriteLine("bill amount for " + Units + " units is " + BillAmount);
                }
                else
                    Console.WriteLine("please enter a valid value for Units used");
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