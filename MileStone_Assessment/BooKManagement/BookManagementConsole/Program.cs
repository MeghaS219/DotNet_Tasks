using BooKLibrary;
namespace BookManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();      
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display all Books");
                Console.WriteLine("3. Delete a Book by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddBook(books);
                            break;
                        case 2:
                            DisplayBooks(books);
                            break;
                        case 3:
                            DeleteBook(books);
                            break;
                        case 4:
                            Console.WriteLine("---Exiting---");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }
            }
        }
            
        static void AddBook(List<Book> books)        
        {                
            Book newBook = new Book(0, "", "", 0.0, "", 0);              
            newBook.AddBookDetails();              
            books.Add(newBook);               
            Console.WriteLine("Book added successfully.");           
        }
       
        static void DisplayBooks(List<Book> books)            
        {                
            if (books.Count == 0)               
            {                   
                Console.WriteLine("No books available.");
                return;               
            }                
            foreach (var book in books)                
            {                   
                Console.WriteLine($"Book ID: {book.BookID}, Name: {book.BookName}, ISBN_No: {book.ISBNNo}, Price: {book.Price}, " +
                                      $"Publisher: {book.Publisher}, Pages: {book.NumberOfPages}, Language: {book.Language}, " +
                                      $"LoT: {book.LoT}, Summary: {book.Summary}");               
            }           
        }

        static void DeleteBook(List<Book> books)            
        {
            if (books.Count == 0)
            {
                Console.WriteLine("There is no books in the directory");
            }
            else
            {
                
                Console.WriteLine("Enter Book ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out int bookid))
                {
                    Book bookToDelete = books.Find(b => b.BookID == bookid);
                    if (bookToDelete != null)
                    {
                        books.Remove(bookToDelete);
                        Console.WriteLine("Book deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found in the directory");
                    }
                }
                else 
                { 
                    Console.WriteLine("Please enter a valid Book Id"); 
                }
            }
        }        
    }   
}
