using System;
using WakeOnLan;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Mac Adddress");
            string Mac = Console.ReadLine();
            WakeOnLanClient WOLClient = new WakeOnLanClient();
            WOLClient.Wake(Mac);
            Console.WriteLine("Pulse any key to exit...");
            Console.Read();
        }
    }
}
