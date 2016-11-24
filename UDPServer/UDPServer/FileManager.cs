using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPSensorReceiver
{
    public class FileManager
    {
        public const string fileName = "PiClientInfo.txt";
        public string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string fullPath => Path.Combine(desktopPath, fileName);

        public void SaveClientToFile(Client client)
        {
            List<Client> clients = GetClients();
            client.TimeStamp = DateTime.Now;
            client.Id = clients.Any() ? clients.Last().Id + 1 : 1;
            clients.Add(client);
            var jsonString = JsonConvert.SerializeObject(clients);
            File.WriteAllText(fullPath, jsonString);
        }

        public List<Client> GetClients()
        {
            if (File.Exists(fullPath))
            {
                string jsonString = File.ReadAllText(fullPath);
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(jsonString);
                return clients;
            }
            return new List<Client>();
        }

        public void DeleteClient(int id)
        {
            var clients = GetClients();
            Client client = clients.SingleOrDefault(x => x.Id.Equals(id));
            clients.Remove(client);
            string jsonString = JsonConvert.SerializeObject(clients);
            File.WriteAllText(fullPath,jsonString);
        }
    }
}
