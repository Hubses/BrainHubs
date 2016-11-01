using System;
using System.Threading;

namespace BH.Parser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var timeSpleepParser = 43200000;
            var manager = new Manager();
            Console.WriteLine("Ok");

            while (true)
            {
                manager.Start();
                Console.WriteLine("Ok");
                Console.WriteLine("Parser sleep 12 o'clock");
                Thread.Sleep(timeSpleepParser);
                Console.WriteLine("Parser start work");
            }
        }
    }
}
