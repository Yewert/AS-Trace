using System.Net;

namespace AS_Route
{
    public interface IAddressInfo
    {
        IPAddress Address { get; }
        string Country { get; }
        string AutonomousSystem { get; }
        string InternetServiceProvider { get; }
    }
}