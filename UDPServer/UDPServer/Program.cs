using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDPSensorReceiver;

namespace UDPServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            new CommandManager();
            Console.ReadKey();
            //UdpClient udpReceiver = new UdpClient(7000);
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);
            //try
            //{
            //    while (true)
            //    {
            //        Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);
            //        string receivedData = Encoding.ASCII.GetString(receiveBytes);
            //        Console.WriteLine(receivedData);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
