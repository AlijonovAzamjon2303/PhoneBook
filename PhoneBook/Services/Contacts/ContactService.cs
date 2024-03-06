using PhoneBook.Brokers.Loggings;
using PhoneBook.Brokers.Storages;
using PhoneBook.Models;
using System;

namespace PhoneBook.Services.Contacts
{
    internal class ContactService  :IContactService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ContactService()
        {
            this.storageBroker = new  FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Contact AddContact(Contact contact) =>
            this.storageBroker.AddContact(contact);

        public void ShowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAll();
            
            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogContact(contact);
            }
        }

        public void Update(Contact contact)
        {
            this.storageBroker.UpdateContact(contact);
        }
    }
}
