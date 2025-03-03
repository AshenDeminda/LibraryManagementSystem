using System;

namespace LibraryMS;

public class SortingAlgorithms 
{
    // Bubble Sort by Title 
public static void QuickSortByTitle(Book[] books, int low, int high)
{
    if (low < high)
    {
        int pi = PartitionByTitle(books, low, high);
        QuickSortByTitle(books, low, pi - 1);
        QuickSortByTitle(books, pi + 1, high);
    }
}

private static int PartitionByTitle(Book[] books, int low, int high)
{
    Book pivot = books[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (string.Compare(books[j].Title, pivot.Title) < 0)
        {
            i++;
            var temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }

    var temp1 = books[i + 1];
    books[i + 1] = books[high];
    books[high] = temp1;

    return i + 1;
}
    // Merge Sort by Publication Year 
    public static void MergeSortByYear(Book[] books, int count)
    {
        if (count <= 1)
            return;
            
        MergeSortByYearHelper(books, 0, count - 1);
    }

    private static void MergeSortByYearHelper(Book[] books, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            
            // Sort first and second halves
            MergeSortByYearHelper(books, left, mid);
            MergeSortByYearHelper(books, mid + 1, right);
            
            // Merge the sorted halves
            MergeArrays(books, left, mid, right);
        }
    }

    private static void MergeArrays(Book[] books, int left, int mid, int right)
    {
        // Create temp arrays
        int n1 = mid - left + 1;
        int n2 = right - mid;
        
        Book[] leftArray = new Book[n1];
        Book[] rightArray = new Book[n2];
        
        // Copy data to temp arrays
        for (int x = 0; x < n1; x++)
            leftArray[x] = books[left + x];
        for (int y = 0; y < n2; y++)
            rightArray[y] = books[mid + 1 + y];
        
        // Merge the temp arrays back
        int i = 0, j = 0;
        int k = left;
        
        while (i < n1 && j < n2)
        {
            if (leftArray[i].PublicationYear <= rightArray[j].PublicationYear)
            {
                books[k] = leftArray[i];
                i++;
            }
            else
            {
                books[k] = rightArray[j];
                j++;
            }
            k++;
        }
        
        // Copy remaining elements of leftArray[] if any
        while (i < n1)
        {
            books[k] = leftArray[i];
            i++;
            k++;
        }
        
        // Copy remaining elements of rightArray[] if any
        while (j < n2)
        {
            books[k] = rightArray[j];
            j++;
            k++;
        }
    }

    // Quick Sort by Author
    public static void QuickSortByAuthor(Book[] books, int low, int high)
    {
        if (low < high)
        {
            int pi = PartitionArray(books, low, high);
            QuickSortByAuthor(books, low, pi - 1);
            QuickSortByAuthor(books, pi + 1, high);
        }
    }

    private static int PartitionArray(Book[] books, int low, int high)
    {
        Book pivot = books[high];
        int i = low - 1;
        
        for (int j = low; j < high; j++)
        {
            if (string.Compare(books[j].Author, pivot.Author) < 0)
            {
                i++;
                var temp = books[i];
                books[i] = books[j];
                books[j] = temp;
            }
        }
        
        var temp1 = books[i + 1];
        books[i + 1] = books[high];
        books[high] = temp1;
        
        return i + 1;
    }
}