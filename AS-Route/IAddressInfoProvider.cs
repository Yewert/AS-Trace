using System.Collections.Generic;
using System.Net;

namespace AS_Route
{
    public interface IAddressInfoProvider
    {
        Result<AdressInfo>[] GetInfoForAdresses(IReadOnlyCollection<IPAddress> ipAddresses);
    }
}