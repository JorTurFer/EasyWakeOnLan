using System;
using EasyWakeOnLan;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Mac Adddress");
            string Mac = Console.ReadLine();
            EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
            WOLClient.Wake(Mac);
            Console.WriteLine("Pulse any key to exit...");
            Console.Read();
        }
    }
}
