using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Brokers
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);

        void LogError(Exception exception);
    }
}
