using System;

namespace LibraryMS;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public int NoOfCopies { get; set; }
    public bool IsAvailable { get; set; }

    public Book() 
    {
        IsAvailable = true;
    }


    public Book(string title, string author, string isbn, int noOfCopies, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
        NoOfCopies = noOfCopies;
        IsAvailable = true;
    }

    public override string ToString()
    {
        return $"{Title},{Author},{ISBN},{NoOfCopies},{PublicationYear},{IsAvailable}";
    }
}