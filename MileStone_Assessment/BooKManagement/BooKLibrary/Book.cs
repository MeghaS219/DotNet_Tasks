namespace BooKLibrary
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string ISBNNo { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public string Language { get; set; }
        public string LoT { get; set; }
        public string Summary { get; set; }

        public Book(int id, string name, string isbn, double price, string publisher,int pages, string language = "English", string lot = "Technical", string summary = "")
        {
            BookID = id;
            BookName = name;
            ISBNNo = isbn;
            Price = price;               
            Publisher = publisher;                
            NumberOfPages = pages;                
            Language = language;                
            LoT = lot;                
            Summary = summary;            
        }            
        
        public void AddBookDetails()
        {
            bool isValidID = false;                
            while (!isValidID)               
            {                   
                Console.WriteLine("Please enter book id (Specifically 5 digits)");                                   
                bool isIdInteger = int.TryParse(Console.ReadLine(), out int id);
                if (isIdInteger &&  Convert.ToString(id).Length == 5)
                    
                {                       
                    BookID = id;                       
                    isValidID = true;                    
                }                   
                else                   
                {                       
                    Console.WriteLine("Please enter a valid book Id");                   
                }               
            }               
            Console.WriteLine("Please enter the Book Name");
            BookName = Console.ReadLine();
                
            Console.WriteLine("Enter ISBN Number: ");                
            ISBNNo = Console.ReadLine();
            
            bool IsValidPrice = false;
            while (!IsValidPrice)
            {
                Console.WriteLine("Please Enter the price of the book");
                bool IsPriceDouble = double.TryParse(Console.ReadLine(), out double price);
                if (IsPriceDouble)
                {
                    Price = price;
                    IsValidPrice = true;
                }
                else { Console.WriteLine("Please enter a valid price for the book"); }
            }
                
            Console.WriteLine("Enter Publisher: ");                
            Publisher = Console.ReadLine();
            
            bool IsValidNumber = false;
            while (!IsValidNumber)
            {
                Console.WriteLine("Please Enter the number of pages of the book");
                bool IsNumberInt = int.TryParse(Console.ReadLine(), out int Number);
                if (IsNumberInt && Number>0)
                {
                    NumberOfPages = Number;
                    IsValidNumber = true;
                }
                else { Console.WriteLine("Please enter a valid integer for Number of pages of the book"); }
            }

            Console.WriteLine("Please enter Language");
            Console.WriteLine("For Default language 'English' , press Enter");
            Language = Console.ReadLine();                
            if (string.IsNullOrWhiteSpace(Language))
            {
                Language = "English";
            }                
            bool isValidLot = false;
            while (!isValidLot)
            {
                Console.WriteLine("Please enter LoT (.NET, Java, IMS, V&V, BI, RDBMS): ");
                LoT = Console.ReadLine();
                if (LoT.ToLower() == ".net" || LoT.ToLower() == "java" || LoT.ToLower() == "ims" || LoT.ToLower() == "v&v" || LoT.ToLower() == "bi" || LoT.ToLower() == "rdbms")
                {
                    isValidLot = true;
                }
                else
                {

                    Console.WriteLine("Invalid LoT. Please enter one of the following: .NET, Java, IMS, V&V, BI, RDBMS.");
                }
            }          
        }        
    }    
}