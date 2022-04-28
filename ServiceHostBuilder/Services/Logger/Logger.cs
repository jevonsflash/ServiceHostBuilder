using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostBuilder.Services.Logger
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            Console.WriteLine("Debug:" + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("Error:" + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("Info:" + message);
        }

        public void Trace(string message)
        {
            Console.WriteLine("Trace:" + message);
        }

        public void Warn(string message)
        {
            Console.WriteLine("Warn:" + message);
        }
    }
}
