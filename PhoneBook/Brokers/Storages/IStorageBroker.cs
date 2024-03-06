using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Contact AddContact(Contact contact);
        Contact[] ReadAll();
        void UpdateContact(Contact contact);   
    }
}
