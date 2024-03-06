using PhoneBook.Models;
using System;
using System.IO;

namespace PhoneBook.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Contacts.txt";
        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        public Contact AddContact(Contact contact)
        {
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n";
            File.AppendAllText(FilePath, contactLine);

            return contact;
        }

        public Contact[] ReadAll() 
        {
            string []allLines = File.ReadAllLines(FilePath);
            int count = allLines.Length;    
            Contact[] contacts = new Contact[count];
            
            for(int i = 0; i < count; i++)
            {
                string[] line = allLines[i].Split('*');
                Contact newContact = new Contact()
                {
                    Id = int.Parse(line[0]),
                    Name = line[1],
                    Phone = line[2],
                };
                contacts[i] = newContact;
            }

            return contacts;
        }

        public void UpdateContact(Contact contact)
        {
            Contact[] contacts = this.ReadAll();
            
            for(int i = 0;i < contacts.Length;i++)
            {
                if (contacts[i].Id == contact.Id)
                {
                    contacts[i] = contact;
                    break;
                }
            }

            File.WriteAllText(FilePath, string.Empty);

            foreach(Contact contact1 in contacts)
            {
                this.AddContact(contact1);
            }
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();  
            }
        }
    }
}
