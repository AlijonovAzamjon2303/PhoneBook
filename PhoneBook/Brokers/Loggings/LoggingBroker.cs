﻿using PhoneBook.Models;
using System;

namespace PhoneBook.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInformation(string message) =>
            Console.WriteLine(message);


        public void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }

        public void LogContact(Contact contact)
        {
            Console.WriteLine($"{contact.Id} || {contact.Name} || {contact.Phone}");
        }

        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }
    }
}
