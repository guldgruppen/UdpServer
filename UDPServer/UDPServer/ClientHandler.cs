using Newtonsoft.Json;
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
        private Temperatur _temperatur;
        public ClientHandler(int port)
        {
            udpReceiver = new UdpClient(port);
            receiverEndPoint = new IPEndPoint(IPAddress.Any, port);        
        }

        public void Broadcast()
        {         
            try
            {
                UdpBroadcaster.IsRunning = true;
                while (UdpBroadcaster.IsRunning)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref receiverEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);
                    _temperatur = new Temperatur { Name = receivedData, };
                    string jsonString = JsonConvert.SerializeObject(_temperatur);
                    Console.WriteLine(receivedData);
                    _udpBroadcaster.BroadcastMessage(Encoding.ASCII.GetBytes(jsonString));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
