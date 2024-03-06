using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Contacts
{
    internal interface IContactService
    {
        Contact AddContact(Contact contact);
        void ShowContacts();
    }
}
