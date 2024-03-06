using PhoneBook.Models;
using PhoneBook.Services.Contacts;
using System;
class Program
{
    static void Main()
    {
        IContactService contactService = new ContactService();
        string userChoice;
        do
        {
            PrintMenu();
            Console.Write("Enter your choice:");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    {
                        Console.Clear();
                        Contact contact = new Contact();

                        Console.Write("Enter id: ");
                        string userIdStr = Console.ReadLine();
                        int userId = Convert.ToInt32(userIdStr);
                        contact.Id = userId;

                        Console.Write("Enter name: ");
                        string nameOfItem = Console.ReadLine();
                        contact.Name = nameOfItem;

                        Console.Write("Enter phoneNumber: ");
                        string phoneNumberOfItem = Console.ReadLine();
                        contact.Phone = phoneNumberOfItem;
                        contactService.AddContact(contact);
                    }
                    break;
                case "2":
                    {
                        Console.Clear();
                        contactService.ShowContacts(); 
                    }
                    break;
                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to delete");
                        Console.Write("Enter id:");
                        string deleteWithIdStr = Console.ReadLine();
                        int deleteWithId = Convert.ToInt32(deleteWithIdStr);
                        contactService.Delete(deleteWithId);
                    }
                    break;
                case "4":
                    {
                        Contact newContact = new Contact();
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want  to edit");
                        Console.Write("Enter an id:");
                        string idStr = Console.ReadLine();
                        int id = Convert.ToInt32(idStr);
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        Console.Write("Enter phoneNumber:");
                        string phoneNumber = Console.ReadLine();
                        newContact.Id = id;
                        newContact.Name = name;
                        newContact.Phone = phoneNumber;
                        contactService.Update(newContact);
                    }
                    break;

                case "0": break;

                default:
                    Console.WriteLine("You entered wrong input, Try again");
                    break;
            }
        }
        while (userChoice != "0");

        Console.WriteLine("The app has been finished");
    }
    public static void PrintMenu()
    {
        Console.WriteLine("1.Add phone books");
        Console.WriteLine("2.Display phoneBooks");
        Console.WriteLine("3.Delete phone book by id");
        Console.WriteLine("4.Update by id");
        Console.WriteLine("0.Exit");
    }
}