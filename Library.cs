using System;
using System.IO;

namespace LibraryMS;

public class Library
{
    private DynamicArray books;
    private MemberList members;
    private string filePath = "library_data.txt";
    private string memberFilePath = "member_data.txt";

    public Library()
    {
        books = new DynamicArray();
        members = new MemberList();
        //LoadData();
    }

    public void AddBook(Book book)
    {
        books.AddBook(book);
        // Auto-save
        SaveData();
    }

    public void RemoveBook(string isbn)
    {
        books.RemoveBook(isbn);
        // Auto-save
        SaveData();
    }

    public Book? SearchBook(string isbn)
    {
        return books.SearchBook(isbn);
    }
    
    public Book[] SearchBooksByTitle(string title)
    {
        Book[] allBooks = books.GetBooks();
        int count = books.GetCount();
        return SearchingAlgorithms.LinearSearchByTitle(allBooks, count, title);
    }
    
    
    public Book BinarySearchBookByISBN(string isbn)
    {
        Book[] allBooks = books.GetBooks();
        int count = books.GetCount();
        return SearchingAlgorithms.BinarySearchByISBN(allBooks, count, isbn);
    }
    
    public Book[] SearchBooksByAuthor(string author)
    {
        Book[] allBooks = books.GetBooks();
        int count = books.GetCount();
        return SearchingAlgorithms.LinearSearchByAuthor(allBooks, count, author);
    }
    
    public Book[] SearchBooksByYear(int year)
    {
        Book[] allBooks = books.GetBooks();
        int count = books.GetCount();
        return SearchingAlgorithms.LinearSearchByYear(allBooks, count, year);
    }

    public void DisplayAllBooks()
    {
        books.DisplayAllBooks();
    }
    
    public void DisplayAllBooks(string sortBy)
    {
        books.DisplayAllBooks(sortBy);
    }


    public void AddMember(string name)
    {
        members.AddMember(name);
        // Auto-save 
        SaveData();
    }

    public void RemoveMember(string name)
    {
        members.RemoveMember(name);
        // Auto-save 
        SaveData();
    }

    public void DisplayAllMembers()
    {
        members.DisplayAllMembers();
    }

    //Issue Books
    public bool IssueBook(string isbn)
    {
        Book? book = books.SearchBook(isbn);
        if (book != null)
        {
            if (book.NoOfCopies > 0)
            {
                book.NoOfCopies -= 1;
                
                // Update availability status if no copies left
                if (book.NoOfCopies == 0)
                {
                    book.IsAvailable = false;
                }
                
                // Auto-save
                SaveData();
                return true;
            }
            else
            {
                Console.WriteLine($"\nError: No copies of '{book.Title}' are available for issue.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("\nError: Book not found.");
            return false;
        }
    }

    //Return Books
    public bool ReturnBook(string isbn)
    {
        Book? book = books.SearchBook(isbn);
        if (book != null)
        {
            book.NoOfCopies += 1;
            
            // Update availability status if it was previously unavailable
            if (!book.IsAvailable)
            {
                book.IsAvailable = true;
            }
            
            // Auto-save
            SaveData();
            Console.WriteLine($"\nBook '{book.Title}' has been returned successfully.");
            return true;
        }
        else
        {
            Console.WriteLine("\nError: Book not found.");
            return false;
        }
    }

    public void LoadData()
    {
        try
        {
            // Clear existing data before loading
            books = new DynamicArray();
            members = new MemberList();
            
            // Load books
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    
                    string[] parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        Book book = new Book
                        {
                            Title = parts[0],
                            Author = parts[1],
                            ISBN = parts[2],
                            NoOfCopies = int.Parse(parts[3]),
                            PublicationYear = int.Parse(parts[4]),
                            IsAvailable = bool.Parse(parts[5])
                        };
                        books.AddBook(book);
                    }
                }
                Console.WriteLine($"Loaded {lines.Length} books from storage.");
            }

            // Load members
            if (File.Exists(memberFilePath))
            {
                string[] memberLines = File.ReadAllLines(memberFilePath);
                foreach (string line in memberLines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        members.AddMember(line);
                    }
                }
                Console.WriteLine($"Loaded {memberLines.Length} members from storage.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

    public void SaveData()
    {
        try
        {
            // Create directories if they don't exist
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            directory = Path.GetDirectoryName(memberFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            // Save books - completely overwrite the file
            using (StreamWriter writer = new StreamWriter(filePath, false)) // false means overwrite
            {
                Book[] allBooks = books.GetBooks();
                int bookCount = books.GetCount();
                
                for (int i = 0; i < bookCount; i++)
                {
                    writer.WriteLine(allBooks[i].ToString());
                }
                
                Console.WriteLine($"Saved {bookCount} books to {filePath}");
            }

            // Save members - completely overwrite the file
            using (StreamWriter writer = new StreamWriter(memberFilePath, false)) // false means overwrite
            {
                string[] memberNames = members.GetAllMemberNames();
                
                foreach (string member in memberNames)
                {
                    writer.WriteLine(member);
                }
                
                Console.WriteLine($"Saved {memberNames.Length} members to {memberFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }
}