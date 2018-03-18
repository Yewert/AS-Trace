using System.Collections.Generic;
using System.Net;

namespace AS_Route
{
    public interface ITracer
    {
        IEnumerable<string> GetOutputAndAdresses(string address, int maxHops = 30);
        bool TryParseIP(string outputLine, out IPAddress ipAddress);
    }
}