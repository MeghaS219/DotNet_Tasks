namespace Desctructorvsconstructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3];

            for (int i = 0; i < people.Length; i++)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                people[i] = new Person(name);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}