using System;
using LibraryMS;

Library library = new Library();
library.LoadData();

while (true)
{
    Console.WriteLine("\n=========================================");
    Console.WriteLine("   Welcome to Library Management System");
    Console.WriteLine("=========================================");
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Remove Book");
    Console.WriteLine("3. Search Book");
    Console.WriteLine("4. Display All Books");
    Console.WriteLine("5. Add Member");
    Console.WriteLine("6. Remove Member");
    Console.WriteLine("7. Display All Members");
    Console.WriteLine("8. Advanced Search");
    Console.WriteLine("9. Issue Book");
    Console.WriteLine("10. Return Book");  
    Console.WriteLine("11. Exit");        
    Console.Write("\nEnter your choice: ");
    
    string? choice = Console.ReadLine();
    
    switch (choice) 
    {
        case "1": // Add a book
            Console.Write("\nEnter book title: ");
            string? title = Console.ReadLine() ?? "";
            Console.Write("\nEnter book author: ");
            string? author = Console.ReadLine() ?? "";
            Console.Write("\nEnter book ISBN: ");
            string? isbn = Console.ReadLine() ?? "";
            
            // Input validation
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("\nError: All fields must be filled. Book not added.");
                break;
            }

            Console.Write("\nEnter number of copies: ");
            if (!int.TryParse(Console.ReadLine(), out int noOfCopies) || noOfCopies <= 0)
            {
                Console.WriteLine("\nError: Invalid number of copies. Book not added.");
                break;
            }
            
            Console.Write("\nEnter publication year: ");
            if (!int.TryParse(Console.ReadLine(), out int publicationYear) || publicationYear <= 0)
            {
                Console.WriteLine("\nError: Invalid publication year. Book not added.");
                break;
            }
            
            Book book = new Book(title, author, isbn, noOfCopies, publicationYear);
            library.AddBook(book);
            Console.WriteLine("\nBook added successfully!");
            break;
            
        case "2": // Remove a book
            Console.Write("\nEnter ISBN of book to remove: ");
            string? isbnToRemove = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnToRemove))
            {
                Console.WriteLine("\nError: ISBN cannot be empty.");
                break;
            }
            library.RemoveBook(isbnToRemove);
            break;
            
        case "3": // Search a book
            Console.Write("\nEnter ISBN to search: ");
            string? isbnToSearch = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnToSearch))
            {
                Console.WriteLine("\nError: ISBN cannot be empty.");
                break;
            }
            
            Book? foundBook = library.SearchBook(isbnToSearch);
            if (foundBook != null)
            {
                Console.WriteLine();
                Console.WriteLine($"\nBook found: {foundBook.Title} by {foundBook.Author}");
                Console.WriteLine($"ISBN: {foundBook.ISBN}, Publication Year: {foundBook.PublicationYear}");
                Console.WriteLine($"Copies: {foundBook.NoOfCopies}, Available: {foundBook.IsAvailable}");
                Console.WriteLine();
            }
           
            break;
            
        case "4": // Display all books
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Display ordered by title");
            Console.WriteLine("3. Display ordered by author");
            Console.WriteLine("4. Display ordered by publication year");
            Console.Write("\nEnter your choice: ");
            string? displayChoice = Console.ReadLine();
            
            switch (displayChoice)
            {
                case "1":
                    library.DisplayAllBooks();
                    break;
                case "2":
                    library.DisplayAllBooks("title");
                    break;
                case "3":
                    library.DisplayAllBooks("author");
                    break;
                case "4":
                    library.DisplayAllBooks("publication year");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Displaying unsorted books:");
                    library.DisplayAllBooks();
                    break;
            }
            break;
            
        case "5": // Add a member
            Console.Write("\nEnter member name: ");
            string? memberName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(memberName))
            {
                Console.WriteLine("\nError: Member name cannot be empty.");
                break;
            }
            library.AddMember(memberName);
            Console.WriteLine("\nMember added successfully!");
            break;
            
        case "6": // Remove a member
            Console.Write("\nEnter member name to remove: ");
            string? memberToRemove = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(memberToRemove))
            {
                Console.WriteLine("\nError: Member name cannot be empty.");
                break;
            }
            library.RemoveMember(memberToRemove);
            break;
            
        case "7": // Display all members
            Console.WriteLine("\nAll Members:");
            library.DisplayAllMembers();
            break;
            
        case "8": // Advanced Search
            Console.WriteLine("\nChoose search type:");
            Console.WriteLine("1. Search by title");
            Console.WriteLine("2. Search by author");
            // Console.WriteLine("3. Search by ISBN (Linear Search)");
            Console.WriteLine("3. Search by ISBN");
            Console.WriteLine("4. Search by publication year");
            Console.Write("\nEnter your choice: ");
            string? searchChoice = Console.ReadLine();
        
            switch (searchChoice)
            {
                case "1":
                    Console.Write("\nEnter title to search: ");
                    string? titleToSearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(titleToSearch))
                    {
                        Console.WriteLine("\nError: Title cannot be empty.");
                        break;
                    }
                
                    Book[] foundBooksByTitle = library.SearchBooksByTitle(titleToSearch);
                    if (foundBooksByTitle.Length > 0)
                    {
                        Console.WriteLine($"\nFound {foundBooksByTitle.Length} books with title containing '{titleToSearch}':");
                        for (int i = 0; i < foundBooksByTitle.Length; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Book found: {foundBooksByTitle[i].Title} by {foundBooksByTitle[i].Author}");
                            Console.WriteLine($"ISBN: {foundBooksByTitle[i].ISBN}, Publication Year: {foundBooksByTitle[i].PublicationYear}");
                            Console.WriteLine($"Copies: {foundBooksByTitle[i].NoOfCopies}, Available: {foundBooksByTitle[i].IsAvailable}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo books found with title containing '{titleToSearch}'.");
                    }
                    break;
                
                case "2":
                    Console.Write("\nEnter author to search: ");
                    string? authorToSearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(authorToSearch))
                    {
                        Console.WriteLine("\nError: Author cannot be empty.");
                        break;
                    }
                
                    Book[] booksByAuthor = library.SearchBooksByAuthor(authorToSearch);
                    if (booksByAuthor.Length > 0)
                    {
                        Console.WriteLine($"\nFound {booksByAuthor.Length} books by author containing '{authorToSearch}':");
                        for (int i = 0; i < booksByAuthor.Length; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Book found: {booksByAuthor[i].Title} by {booksByAuthor[i].Author}");
                            Console.WriteLine($"ISBN: {booksByAuthor[i].ISBN}, Publication Year: {booksByAuthor[i].PublicationYear}");
                            Console.WriteLine($"Copies: {booksByAuthor[i].NoOfCopies}, Available: {booksByAuthor[i].IsAvailable}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo books found by author containing '{authorToSearch}'.");
                    }
                    break;
                
                
                case "3":
                    Console.Write("\nEnter exact ISBN to search: ");
                    string? isbnForBinarySearch = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(isbnForBinarySearch))
                    {
                        Console.WriteLine("\nError: ISBN cannot be empty.");
                        break;
                    }

                    Book foundBookBinary = library.BinarySearchBookByISBN(isbnForBinarySearch);
                    if (foundBookBinary != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Book found: {foundBookBinary.Title} by {foundBookBinary.Author}");
                        Console.WriteLine($"ISBN: {foundBookBinary.ISBN}, Publication Year: {foundBookBinary.PublicationYear}");
                        Console.WriteLine($"Copies: {foundBookBinary.NoOfCopies}, Available: {foundBookBinary.IsAvailable}");
                    }
                    else
                    {
                        Console.WriteLine("\nNo book found with that exact ISBN.");
                    }
                    break;
                
                case "4":
                    Console.Write("\nEnter publication year to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int yearToSearch) || yearToSearch <= 0)
                    {
                        Console.WriteLine("\nError: Invalid year format.");
                        break;
                    }
                
                    Book[] booksByYear = library.SearchBooksByYear(yearToSearch);
                    if (booksByYear.Length > 0)
                    {
                        Console.WriteLine($"\nFound {booksByYear.Length} books published in {yearToSearch}:");
                        for (int i = 0; i < booksByYear.Length; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Book found: {booksByYear[i].Title} by {booksByYear[i].Author}");
                            Console.WriteLine($"ISBN: {booksByYear[i].ISBN}, Publication Year: {booksByYear[i].PublicationYear}");
                            Console.WriteLine($"Copies: {booksByYear[i].NoOfCopies}, Available: {booksByYear[i].IsAvailable}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo books found from year {yearToSearch}.");
                    }
                    break;
                
                default:
                    Console.WriteLine("\nInvalid search choice.");
                    break;
            }
            break;
            
        case "9": // Issue a book
            Console.Write("\nEnter ISBN of book to issue: ");
            string? isbnToIssue = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnToIssue))
            {
                Console.WriteLine("\nError: ISBN cannot be empty.");
                break;
            }
            
            if (library.IssueBook(isbnToIssue))
            {
                Console.WriteLine("\nBook issued successfully!");
            }
            break;

        case "10": // Return a book
            Console.Write("\nEnter ISBN of book to return: ");
            string? isbnToReturn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnToReturn))
            {
                Console.WriteLine("\nError: ISBN cannot be empty.");
                break;
            }
            library.ReturnBook(isbnToReturn);
            break;

        case "11": // Exit
            library.SaveData(); // Save before exiting
            Console.WriteLine("\nThank you for using Library Management System!");
            return;
            
        default:
            Console.WriteLine("\nInvalid choice. Please try again.");
            break;
    }
}
