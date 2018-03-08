using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AS_Route
{
    public class IpApiAddressInfoProvider : IAddressInfoProvider
    {
        public Result<AdressInfo>[] GetInfoForAdresses(IReadOnlyCollection<IPAddress> ipAddress)
        {
            return ProcessAllRequests(ipAddress);
        }

        private Result<AdressInfo>[] ProcessAllRequests(IReadOnlyCollection<IPAddress> ipAddresses)
        {
            return Task.WhenAll(ipAddresses.Select(GetAddressInfoAsync)).Result;
        }

        private async Task<Result<AdressInfo>> GetAddressInfoAsync(IPAddress ipAddress)
        {
            Program.Log.Info($"Processing request for {ipAddress}");
            var res = await Result.OfAsync(async () =>
            {
                var request = WebRequest.CreateHttp(
                    Uri.EscapeUriString($"http://ip-api.com/json/{ipAddress}"));
                var response = await ProcessRequestAsync(request);
                var responseContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
                var isSuccessful = responseContent["status"] == "success";
                if (isSuccessful)
                    return new AdressInfo(ipAddress,
                        responseContent["country"],
                        responseContent["as"],
                        responseContent["isp"]);
                throw new ArgumentException("Unsuccessful request");
            });
            return res;
        }

        private async Task<string> ProcessRequestAsync(WebRequest request)
        {
            var timer = Stopwatch.StartNew();
            using (var response = await request.GetResponseAsync())
            {
                var result = await new StreamReader(
                        response.GetResponseStream() ?? throw new Exception(),
                        Encoding.UTF8)
                    .ReadToEndAsync();
                Program.Log.Info($"Response for {request.RequestUri} received in {timer.ElapsedMilliseconds} ms");
                return result;
            }
        }
    }
}