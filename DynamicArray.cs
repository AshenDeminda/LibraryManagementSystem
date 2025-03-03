using System;

namespace LibraryMS;

public class DynamicArray
{
    private Book[] books;
    private int capacity;
    private int count;

    public DynamicArray()
    {
        capacity = 100;
        count = 0;
        books = new Book[capacity];
    }

    public void AddBook(Book book)
    {
        if (count == capacity)
        {
            Resize();
        }
        books[count] = book;
        count++;
    }

    public void RemoveBook(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit))
        {
            Console.WriteLine("\nError: Invalid ISBN. It must have exactly 13 digits.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            if (books[i].ISBN == isbn)
            {
                for (int j = i; j < count - 1; j++)
                {
                    books[j] = books[j + 1];
                }
                count--;
                Console.WriteLine("\nBook removed successfully.");
                return;
            }
        }

        Console.WriteLine("\nError: Book not found.");
    }

    public Book? SearchBook(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit))
        {
            Console.WriteLine("\nError: Invalid ISBN. It must have exactly 13 digits.");
            return null;
        }

        for (int i = 0; i < count; i++)
        {
            if (books[i].ISBN == isbn)
            {
                return books[i];
            }
        }

        Console.WriteLine("\nError: Book not found.");
        return null;
    }

    public void DisplayAllBooks()
    {
        if (count == 0)
        {
            Console.WriteLine("\nNo books available.");
            return;
        }
        
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n{i+1}. {books[i].Title} by {books[i].Author}, No of Copies: {books[i].NoOfCopies} (ISBN: {books[i].ISBN})");
        }
    }
    
    public void DisplayAllBooks(string sortBy)
    {
        if (count == 0)
        {
            Console.WriteLine("\nNo books available.");
            return;
        }
        
        // Create a temporary array with exactly the number of books we have
        Book[] booksToSort = new Book[count];
        for (int i = 0; i < count; i++)
        {
            booksToSort[i] = books[i];
        }
        
        // Sort based on parameter
        switch (sortBy)
        {
            case "title":
                SortingAlgorithms.QuickSortByTitle(booksToSort, 0, count - 1);
                break;
            case "author":
                SortingAlgorithms.QuickSortByAuthor(booksToSort, 0, count - 1);
                break;
            case "publication year":
                SortingAlgorithms.MergeSortByYear(booksToSort, count);
                break;
            default:
                // No sorting
                break;
        }
        
        // Display sorted books
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n{i+1}. {booksToSort[i].Title} by {booksToSort[i].Author} (ISBN: {booksToSort[i].ISBN}, Year: {booksToSort[i].PublicationYear})");
        }
    }

    private void Resize()
    {
        capacity += 10;
        Book[] newArray = new Book[capacity];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = books[i];
        }
        books = newArray;
    }

    public Book[] GetBooks()
    {
        return books;
    }
    
    public Book[] GetBooksArray()
    {
        Book[] booksArray = new Book[count];
        for (int i = 0; i < count; i++)
        {
            booksArray[i] = books[i];
        }
        return booksArray;
    }

    public int GetCount()
    {
        return count;
    }
}
