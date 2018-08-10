using System;
using EasyWakeOnLan;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Process();
        }
        static async void Process()
        {
            Console.WriteLine("Enter a Mac Adddress");
            string Mac = Console.ReadLine();
            EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
            //Sync
            WOLClient.Wake(Mac);
            //Async
            await WOLClient.WakeAsync(Mac);
            Console.WriteLine("Pulse any key to exit...");
            Console.Read();
        }
    }
}
