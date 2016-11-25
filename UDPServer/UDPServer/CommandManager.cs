using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPServer;

namespace UDPSensorReceiver
{
    public class CommandManager
    {
        private FileManager _fileManager;
        private bool _isRunning;
        private bool _isCommandLoopRunning;
        private List<Task> TaskPool = new List<Task>();
        public CommandManager()
        {
            _fileManager = new FileManager();
            BeginCommandLoop();
        }
        public void BeginCommandLoop()
        {
            Console.WriteLine("                               Udp Server Manager");
            Console.WriteLine("****************************************************************************************");
            Console.WriteLine("type help to see commands");
            _isCommandLoopRunning = true;
            while (_isCommandLoopRunning)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "insert":
                        Console.WriteLine();
                        InsertClient();
                        break;
                    case "details":
                        ShowClientDetails();
                        break;
                    case "count":
                        Console.WriteLine();
                        GetNumberOfClients();
                        break;
                    case "delete":
                        Console.WriteLine();
                        DeleteClient();
                        break;
                    case "execute":
                        Console.WriteLine();
                        ReceiveAndSendData();
                        break;
                    case "stop":
                        Console.WriteLine();
                        StopReceivingData();
                        break;
                    case "exit":
                        Console.WriteLine();
                        ExitShell();
                        break;
                    case "help":
                        Console.WriteLine();
                        ShowAvailableCommands();
                        break;
                    default:
                        Console.WriteLine();                    
                        Console.WriteLine("This command is not available");
                        break;                   
                }
            }
        }
        public void ShowClientDetails()
        {
            foreach(var client in _fileManager.GetClients())
            {
                Console.WriteLine("Id: "+client.Id+", Name: "+client.Name + ", Port: "+client.Port+", time attached: "+client.TimeStamp);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void ShowAvailableCommands()
        {
            Console.WriteLine("type 'insert' to insert a client");
            Console.WriteLine("type 'details' to see client details");
            Console.WriteLine("type 'count' to see clients attached");
            Console.WriteLine("type 'execute' to receive and sending data");
            Console.WriteLine("type 'stop' to stop receiving and sending data");
            Console.WriteLine("type 'delete' to delete a client");
            Console.WriteLine("type 'exit' to delete a client");
            Console.WriteLine();
        }
        public void ExitShell()
        {
            _isCommandLoopRunning = false;
            Environment.Exit(1);
        }
        public void InsertClient()
        {
            Console.WriteLine("Enter client name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter port number");
            int port = Int32.Parse(Console.ReadLine());
            _fileManager.SaveClientToFile(new Client{Name = name, Port = port});
            Console.WriteLine();
            Console.WriteLine("client inserted successfully");
        }
        public void GetNumberOfClients()
        {
            Console.WriteLine(String.Format("{0} clients is attached to the server", _fileManager.GetClients().Count()));
            Console.WriteLine();
        }

        public void StopReceivingData()
        {
            UdpBroadcaster.IsRunning = false;

            Console.WriteLine("Receiving and sending data stopped successfully");
            Console.WriteLine("bug causes program to crash if you excecute again");
        }
        public void DeleteClient()
        {
            Console.WriteLine("Enter client id");
            int id = Int32.Parse(Console.ReadLine());
            _fileManager.DeleteClient(id);
            Console.WriteLine("Client deleted Successfully");
        }
        public void ReceiveAndSendData()
        {
            var clients = _fileManager.GetClients();
                foreach (var client in clients)
                {
                    ClientHandler clientHandler = new ClientHandler(client.Port);
                    Task.Factory.StartNew(() => clientHandler.Broadcast());
                }
            
        }

    }
}
