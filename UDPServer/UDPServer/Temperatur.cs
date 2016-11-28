using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    public partial class Temperatur
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public DateTime Timestamp { get; set; }

        public int Location { get; set; }

        public int Status { get; set; }

    }
}
