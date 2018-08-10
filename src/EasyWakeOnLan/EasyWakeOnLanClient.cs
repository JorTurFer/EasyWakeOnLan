using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyWakeOnLan
{
    /// <summary>
    /// Class to Send Magic Packet to Wake On Lan
    /// </summary>
    public class EasyWakeOnLanClient : UdpClient, IEasyWakeOnLanCient
    {
        public EasyWakeOnLanClient() : base()
        {
        }

        /// <summary>
        /// Wake a PC
        /// </summary>
        /// <param name="Mac">NIC Mac to wake</param>
        public void Wake(string Mac)
        {
            //Parse the mac
            var MacParsed = Regex.Replace(Mac, "[-|:]", "");
            
            //set sending bites
            int Counter = 0;
            //buffer to be send
            byte[] Bytes = new byte[1024];   // more than enough :-)
                                             //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                Bytes[Counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    Bytes[Counter++] =
                        byte.Parse(MacParsed.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }
            //now send wake up packet
            IPEndPoint destiny = new IPEndPoint(IPAddress.Broadcast, 40000);
            SendAsync(Bytes, 1024, destiny);
        }
        /// <summary>
        /// Wake a PC Async
        /// </summary>
        /// <param name="Mac">NIC Mac to wake</param>
        public async Task WakeAsync(string Mac)
        {
            //Parse the mac
            var MacParsed = Regex.Replace(Mac, "[-|:]", "");

            //set sending bites
            int Counter = 0;
            //buffer to be send
            byte[] Bytes = new byte[1024];   // more than enough :-)
                                             //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                Bytes[Counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    Bytes[Counter++] =
                        byte.Parse(MacParsed.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }
            //now send wake up packet
            IPEndPoint destiny = new IPEndPoint(IPAddress.Broadcast, 40000);
            await SendAsync(Bytes, 1024, destiny);
        }
    }
}