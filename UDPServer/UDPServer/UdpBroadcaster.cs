using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    public class UdpBroadcaster
    {
        private static UdpBroadcaster udpBroadcaster;
        public static UdpBroadcaster GetInstance => udpBroadcaster ?? new UdpBroadcaster();
        public static bool IsRunning = false;
        private UdpClient udpSender;
        private IPEndPoint senderEndPoint;
        private UdpBroadcaster()
        {
            udpSender = new UdpClient();
            udpSender.EnableBroadcast = true;
            senderEndPoint = new IPEndPoint(IPAddress.Broadcast, 8888);
        }

        public void BroadcastMessage(Byte[] bytesToSend)
        {
            udpSender.Send(bytesToSend, bytesToSend.Length, senderEndPoint);
        }
    }
}
