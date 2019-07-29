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
        public const int Port = 40000;
        public EasyWakeOnLanClient() : base()
        {
        }

        /// <summary>
        /// Wake a PC
        /// </summary>
        /// <param name="mac">NIC Mac to wake</param>
        public void Wake(string mac)
        {
            var bytes = GetBytes(mac);
            //now send wake up packet
            var destiny = new IPEndPoint(IPAddress.Broadcast, Port);
            SendAsync(bytes, bytes.Length, destiny);
        }
        /// <summary>
        /// Wake a PC Async
        /// </summary>
        /// <param name="mac">NIC Mac to wake</param>
        public async Task WakeAsync(string mac)
        {
            var bytes = GetBytes(mac);
            //now send wake up packet
            var destiny = new IPEndPoint(IPAddress.Broadcast, Port);
            await SendAsync(bytes, bytes.Length, destiny);
        }
        private static byte[] GetBytes(string mac)
        {
            //Parse the mac
            var macParsed = Regex.Replace(mac, "[-|:]", "");

            //set sending bites
            var counter = 0;
            //buffer to be send
            var bytes = new byte[128];   // more than enough :-)
                                          //first 6 bytes should be 0xFF
            for (var y = 0; y < 6; y++)
            {
                bytes[counter++] = 0xFF;
            }
            //now repeat MAC 16 times
            for (var y = 0; y < 16; y++)
            {
                var i = 0;
                for (var z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        System.Byte.Parse(macParsed.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }
            return bytes;
        }
    }
}