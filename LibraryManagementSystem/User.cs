using System;

namespace LibraryManagementSystem;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public  string Phone { get; set; }   //check this maybe there is another data typefor this
    public string Role { get; set; }     //user type ex:-  student, blah blah
    public User(int id, string name, string email, string phone, string role)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Role = role;
    }

}
