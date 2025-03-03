using System;

namespace LibraryMS;

public class SearchingAlgorithms 
{
    // Linear Search by Title
    public static Book[] LinearSearchByTitle(Book[] books, int count, string title)
    {
        // Create array to store results (maximum possible is count)
        Book[] results = new Book[count];
        int resultCount = 0;
        
        for (int i = 0; i < count; i++)
        {
            if (books[i].Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            {
                results[resultCount] = books[i];
                resultCount++;
            }
        }
        
        // Create properly sized result array
        Book[] finalResults = new Book[resultCount];
        for (int i = 0; i < resultCount; i++)
        {
            finalResults[i] = results[i];
        }
        
        return finalResults;
    }
    
    // Linear Search by Author
    public static Book[] LinearSearchByAuthor(Book[] books, int count, string author)
    {
        Book[] results = new Book[count];
        int resultCount = 0;
        
        for (int i = 0; i < count; i++)
        {
            if (books[i].Author.Contains(author, StringComparison.OrdinalIgnoreCase))
            {
                results[resultCount] = books[i];
                resultCount++;
            }
        }
        
        Book[] finalResults = new Book[resultCount];
        for (int i = 0; i < resultCount; i++)
        {
            finalResults[i] = results[i];
        }
        
        return finalResults;
    }
    
    // Linear Search by Publication Year
    public static Book[] LinearSearchByYear(Book[] books, int count, int year)
    {
        Book[] results = new Book[count];
        int resultCount = 0;
        
        for (int i = 0; i < count; i++)
        {
            if (books[i].PublicationYear == year)
            {
                results[resultCount] = books[i];
                resultCount++;
            }
        }
        
        Book[] finalResults = new Book[resultCount];
        for (int i = 0; i < resultCount; i++)
        {
            finalResults[i] = results[i];
        }
        
        return finalResults;
    }
    
    // Binary Search by ISBN (requires sorted array)
    public static Book BinarySearchByISBN(Book[] books, int count, string isbn)
    {
        // First, sort the array by ISBN
        SortBooksByISBN(books, count);
        
        int low = 0;
        int high = count - 1;
        
        while (low <= high)
        {
            int mid = (low + high) / 2;
            
            int comparison = string.Compare(books[mid].ISBN, isbn, StringComparison.OrdinalIgnoreCase);
            
            if (comparison == 0)
            {
                return books[mid]; // Found exact match
            }
            else if (comparison < 0)
            {
                low = mid + 1; // Search in the right half
            }
            else
            {
                high = mid - 1; // Search in the left half
            }
        }
        
        return null; // ISBN not found
    }
    
    // Helper method to sort books by ISBN for binary search
    private static void SortBooksByISBN(Book[] books, int count)
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (string.Compare(books[j].ISBN, books[j + 1].ISBN) > 0)
                {
                    // Swap books[j] and books[j+1]
                    Book temp = books[j];
                    books[j] = books[j + 1];
                    books[j + 1] = temp;
                }
            }
        }
    }
}