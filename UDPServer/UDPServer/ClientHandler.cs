using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPServer;

namespace UDPSensorReceiver
{
    public class ClientHandler
    {
        private static UdpClient udpReceiver;
        private const double FACTOR = 0.1;

        UdpClient udpSender;
        static IPEndPoint receiverEndPoint;
        IPEndPoint senderEndPoint;
        private UdpBroadcaster _udpBroadcaster = UdpBroadcaster.GetInstance;
        private Temperatur _temperatur;
        private string receivedData;
        private Timer timer;
        public ClientHandler(int port)
        {
            udpReceiver = new UdpClient(port);
            receiverEndPoint = new IPEndPoint(IPAddress.Any, port);
            timer = new Timer(TimeBack, null, 0, 4000);
        }

        private async void TimeBack(object state)
        {
            if (_temperatur != null)
            {
                string jsonData = JsonConvert.SerializeObject(_temperatur);
                using (HttpClient client = new HttpClient())
                {
                    await client.PostAsJsonAsync("http://localhost:28553/TempService.svc/Temperatur/Post/", jsonData);
                }
                Console.WriteLine(jsonData);            
            }
        }

        public void Broadcast()
        {         
            try
            {
                UdpBroadcaster.IsRunning = true;
                while (UdpBroadcaster.IsRunning)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref receiverEndPoint);
                    receivedData = Encoding.ASCII.GetString(receiveBytes);
                    string temp = Filter.GetTempData(receivedData);
                    _temperatur = new Temperatur {Location = 1, Data = (double.Parse(temp)*FACTOR).ToString(), Timestamp = DateTime.Now };
                    string jsonString = JsonConvert.SerializeObject(_temperatur);
                    Console.WriteLine(_temperatur.Data);
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
