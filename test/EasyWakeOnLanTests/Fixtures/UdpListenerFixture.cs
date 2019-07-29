using EasyWakeOnLan;
using EasyWakeOnLanTests.Extensions;
using System;
using System.Net;
using System.Net.Sockets;

namespace EasyWakeOnLanTests.Fixtures
{
    public class UdpListenerFixture
    {
        private string _message;

        public UdpListenerFixture()
        {
            var anyIp = new IPEndPoint(IPAddress.Any, EasyWakeOnLanClient.Port);
            var uState = new UdpState(new UdpClient(anyIp), anyIp);
            uState.Client.BeginReceive(RxCallback, uState);
        }

        public void RxCallback(IAsyncResult result)
        {
            var rState = (UdpState)result.AsyncState;
            var rClient = ((UdpState)result.AsyncState).Client;
            var rEndPoint = ((UdpState)result.AsyncState).Endpoint;
            var rxBytes = rClient.EndReceive(result, ref rEndPoint);
            _message = rxBytes.GetStringFromByteArray();
            rClient.BeginReceive(RxCallback, result.AsyncState);
        }

        public string GetRecivedMessage()
        {
            return _message;
        }

        public void ClearRecivedMessage()
        {
            _message = String.Empty;
        }
    }

    public class UdpState
    {
        public UdpClient Client { get; }
        public IPEndPoint Endpoint { get; }

        public UdpState(UdpClient c, IPEndPoint iep)
        {
            Client = c;
            Endpoint = iep;
        }
    }
}
