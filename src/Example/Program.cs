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
            //Sync
            ProcessSync(Mac);
            //Async
            ProcessAsync(Mac);
            Console.WriteLine("Pulse any key to exit...");
            Console.Read();
        }
        static void ProcessSync(string Mac)
        {
            EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
            WOLClient.Wake(Mac);
        }
        static async void ProcessAsync(string Mac)
        {
            EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
            await WOLClient.WakeAsync(Mac);
        }
    }
}
