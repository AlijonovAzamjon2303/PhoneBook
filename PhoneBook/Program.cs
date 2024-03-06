﻿using PhoneBook.Models;
using PhoneBook.Services.Contacts;

class Program
{
    static void Main()
    {
        IContactService contactService = new ContactService();

        Contact contact = new Contact
        {
            Id = 1,
            Name = "A'zamjon",
            Phone = "+998 94 480 49 00"
        };

        contactService.ShowContacts(); 
    }
}