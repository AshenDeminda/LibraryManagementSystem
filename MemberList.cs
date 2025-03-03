using System;

namespace LibraryMS;

public class MemberList
{
    private Member head;

    public void AddMember(string name)
    {
        Member newNode = new Member(name);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Member temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }

    public void RemoveMember(string name)
    {
        if (head == null)
        {
            Console.WriteLine("\nMember not found.");
            return;
        }

        // Check if name contains the search string (partial match)
        if (head.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        {
            head = head.Next;
            Console.WriteLine("\nMember removed successfully!");
            return;
        }

        Member temp = head;
        while (temp.Next != null && !temp.Next.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        {
            temp = temp.Next;
        }

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("\nMember removed successfully!");
        }
        else
        {
            Console.WriteLine("\nMember not found.");
        }
    }

    public void DisplayAllMembers()
    {
        if (head == null)
        {
            Console.WriteLine("No members available.");
            return;
        }
        
        int count = 1;
        Member temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{count++}. {temp.Name}");
            temp = temp.Next;
        }
    }
    
    public string[] GetAllMemberNames()
    {
        int count = GetCount();
        string[] names = new string[count];
        
        Member temp = head;
        int index = 0;
        while (temp != null)
        {
            names[index++] = temp.Name;
            temp = temp.Next;
        }
        
        return names;
    }
    
    public int GetCount()
    {
        int count = 0;
        Member temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }
}