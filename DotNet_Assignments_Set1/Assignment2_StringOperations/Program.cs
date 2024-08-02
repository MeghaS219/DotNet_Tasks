namespace Assignment2_StringOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            operationThree(str);
        }
        static void operationOne(string str)
        {
            Console.WriteLine(str + str[0]);

        }
        static void operationTwo(string str)
        {
            string outstr="";
            if (str.Length > 1)
            {
                outstr= str[str.Length - 1] + str.Substring(1, str.Length - 2) + str[0];

            }
            else
                outstr = str;
            Console.WriteLine(outstr);

        }
        static void operationThree(string str)
        {
            string outstr = "";
            if (str.Length > 2)
            {
                outstr = str.Substring(0, 3) + str+ str.Substring(0, 3);

            }
            else
                outstr = str+str+str;
            Console.WriteLine(outstr);

        }
    }
}