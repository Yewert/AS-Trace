using System;
using System.Net;
using System.Xml.Serialization;
using log4net;
using log4net.Config;

namespace AS_Route
{
    public static class Program
    {
        public static ILog Log => LogManager.GetLogger("Main");

        public static void Main(string[] args)
        {
            var maxHops = 30;
            XmlConfigurator.Configure();
            if (args.Length > 2 || args.Length < 1 || args[0].Length == 0)
            {
                Console.WriteLine("Bad arguments");
                return;
            }

            if (args.Length == 2)
            {
                if (!int.TryParse(args[1], out maxHops))
                {
                    Console.WriteLine("2nd argument not a number");
                    return;
                }
            }
            
            var astracer = new AutonomouSystemTracer(new TracertTracer(), new IpApiAddressInfoProvider());
            foreach (var line in astracer.Trace(args[0], maxHops))
            {
                Console.WriteLine(line);
            }
        }
    }
}