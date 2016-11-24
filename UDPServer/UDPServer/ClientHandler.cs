using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDPServer;

namespace UDPSensorReceiver
{
    public class ClientHandler
    {
        private UdpClient udpReceiver;
        UdpClient udpSender;
        IPEndPoint receiverEndPoint;
        IPEndPoint senderEndPoint;
        private UdpBroadcaster _udpBroadcaster = UdpBroadcaster.GetInstance;
        public ClientHandler(int port)
        {
            udpReceiver = new UdpClient(port);
            receiverEndPoint = new IPEndPoint(IPAddress.Any, port);        
        }

        public void Broadcast()
        {         
            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref receiverEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    Console.WriteLine(receivedData);
                    _udpBroadcaster.BroadcastMessage(receiveBytes);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
