using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    public class Filter
    {
        public static string GetTempData(string receivedData)
        {
            var result = receivedData.Split();
            return result[21];
        }
    }
}
