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

        public void Delete(int id)
        {
            this.storageBroker.DeleteContact(id);
        }

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
            if(contact is null)
            {
                this.loggingBroker.LogError("Your contact is empty");
                return;
            }
            
            if(contact.Id == 0 || String.IsNullOrEmpty(contact.Name) || String.IsNullOrEmpty(contact.Phone)) 
            {
                this.loggingBroker.LogError("Your contact is invalid");
            }
            
            this.storageBroker.UpdateContact(contact);
        }
    }
}
