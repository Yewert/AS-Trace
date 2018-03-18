using System.Net;

namespace AS_Route
{
    public class AdressInfo : IAddressInfo
    {
        public AdressInfo(IPAddress address, string country, string autonomousSystem, string internetServiceProvider)
        {
            Address = address;
            Country = country;
            AutonomousSystem = autonomousSystem;
            InternetServiceProvider = internetServiceProvider;
        }

        public override string ToString()
        {
            return $"Address: {Address}, Country: {Country}, AutonomousSystem: {AutonomousSystem}, InternetServiceProvider: {InternetServiceProvider}";
        }

        public IPAddress Address { get; }
        public string Country { get; }
        public string AutonomousSystem { get; }
        public string InternetServiceProvider { get; }
    }
}