using System;
using System.Collections.Generic;

namespace AS_Route
{
    public class AutonomouSystemTracer
    {
        private readonly ITracer tracer;
        private readonly IAddressInfoProvider infoProvider;

        public AutonomouSystemTracer(ITracer tracer, IAddressInfoProvider infoProvider)
        {
            this.tracer = tracer ?? throw new ArgumentNullException(nameof(tracer));
            this.infoProvider = infoProvider ?? throw new ArgumentNullException(nameof(infoProvider));
        }
        
        public IEnumerable<string> Trace(string address, int maxHops=30)
        {
            foreach (var line in tracer.GetOutputAndAdresses(address, maxHops))
            {
                Console.WriteLine(line);
                var gotIp = tracer.TryParseIP(line, out var parsedAddress);
                if (!gotIp)
                {
                    Program.Log.Info($"Line \"{line}\" did not match");
                    continue;
                } 
                Program.Log.Info($"Got \"{parsedAddress}\" from \"{line}\"");
                var requestForInfoResult = infoProvider.GetAdressInfo(parsedAddress);
                if (requestForInfoResult.IsSuccess)
                {
                    yield return requestForInfoResult.Value.ToString();
                        
                }
                else
                {
                    yield return requestForInfoResult.Error;
                }
            }
        }
    }
}