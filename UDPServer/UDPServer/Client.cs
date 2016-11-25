using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPSensorReceiver
{
    public class Client
    {
        public int Id { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
