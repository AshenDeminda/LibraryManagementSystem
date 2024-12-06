using System;

namespace LibraryManagementSystem;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Genre { get; set; }
    public int CopyCount { get; set; }
    public Book(string title, string author, string isbn, string genre, int copyCount)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Genre = genre;
        CopyCount = copyCount;
    }
}

