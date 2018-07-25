using System;
using WakeOnLan;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Mac Adddress");
            string mac = Console.ReadLine();
            WakeOnLanClient WOLClient = new WakeOnLanClient();
            WOLClient.Wake(mac);
            Console.WriteLine("Pulse any key to exit...");
            Console.Read();
        }
    }
}
