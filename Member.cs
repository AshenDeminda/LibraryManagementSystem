using System;

namespace LibraryMS;

public class Member
{
    public string Name { get; set; }
    public Member Next { get; set; }

    public Member(string name)
    {
        Name = name;
        Next = null;
    }
}