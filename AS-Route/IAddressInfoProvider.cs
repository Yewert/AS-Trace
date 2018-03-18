using System.Collections.Generic;
using System.Net;

namespace AS_Route
{
    public interface IAddressInfoProvider
    {
        IEnumerable<Result<AdressInfo>> GetAdressesInfoParallel(IEnumerable<IPAddress> ipAddresses);
        Result<AdressInfo> GetAdressInfo(IPAddress ipAddress, int attemptsNumber=10);
        
    }
}