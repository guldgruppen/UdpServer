using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPSensorReceiver
{
    class ConsoleREad
    {
        //static void Main(string[] args)
        //{
        //    UdpClient udpReceiver = new UdpClient(8888);
        //    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8888);
        //    try
        //    {
        //        while (true)
        //        {
        //            Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);
        //            string receivedData = Encoding.ASCII.GetString(receiveBytes);
        //            Console.WriteLine(receivedData);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //static void Sender(string[] args)
        //{
        //    UdpClient udpServer = new UdpClient();
        //    udpServer.EnableBroadcast = true;
        //    IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 9999);

        //    Console.WriteLine("Broadcast started: Press Enter");
        //    Console.ReadLine();

        //    while (true)
        //    {
        //        Byte[] sendBytes = Encoding.ASCII.GetBytes("Det Virker - Nummer 1");
        //        try
        //        {
        //            udpServer.Send(sendBytes, sendBytes.Length, endPoint); //, endPoint
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.ToString());
        //        }
        //        Thread.Sleep(800);
        //    }

        //}
    }
}

