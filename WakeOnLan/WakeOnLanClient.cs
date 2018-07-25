using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace WakeOnLan
{
    /// <summary>
    /// Class to Send Magic Packet to Wake On Lan
    /// </summary>
    public class WakeOnLanClient : UdpClient
    {
        public WakeOnLanClient() : base()
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
            //Connect de client
            Connect(IPAddress.Broadcast, 40000);
            //set sending bites
            int counter = 0;
            //buffer to be send
            byte[] bytes = new byte[1024];   // more than enough :-)
                                             //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(MacParsed.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }
            //now send wake up packet
            Send(bytes, 1024);
        }
    }
}