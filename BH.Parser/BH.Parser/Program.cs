using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BH.Parser.RiaRu;
using BH.Parser.TutBy;

namespace BH.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Console.WriteLine("Ok");
            manager.Start();
            Console.WriteLine("Ok");
            List<DataNews> _list = manager.List;
            Console.WriteLine("Ok");
            foreach (var dataNewse in _list)
            {
                Console.WriteLine("{0}      {1}",dataNewse.Id,dataNewse.Header);
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
