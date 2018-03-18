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
        public IEnumerable<Result<AdressInfo>> GetAdressesInfoParallel(IEnumerable<IPAddress> ipAddress)
        {
            return ProcessAllRequests(ipAddress);
        }

        public Result<AdressInfo> GetAdressInfo(IPAddress ipAddress, int attemptsNumber=10)
        {
            var res = Result.Of(() =>
            {
                var request = WebRequest.CreateHttp(
                    Uri.EscapeUriString($"http://ip-api.com/json/{ipAddress}"));
                Task<string> requestTask = null;
                for (var i = 0; i < attemptsNumber; i++)
                {
                    requestTask = ProcessRequestAsync(request);
                    requestTask.Wait();
                    if (!requestTask.IsCompleted || requestTask.IsFaulted) 
                        continue;
                    break;
                }
                if (ExtractAdressInfo(ipAddress, requestTask, out var adressInfo)) 
                    return adressInfo;
    
                // ReSharper disable once PossibleNullReferenceException
                throw requestTask.Exception;
            });
            return res;
        }

        private IEnumerable<Result<AdressInfo>> ProcessAllRequests(IEnumerable<IPAddress> ipAddresses)
        {
            return Task.WhenAll(ipAddresses.Select(x => GetAddressInfoAsync(x))).Result;
        }

        private async Task<Result<AdressInfo>> GetAddressInfoAsync(IPAddress ipAddress, int attemptsNumber=10)
        {
            if (attemptsNumber <= 0) throw new ArgumentOutOfRangeException(nameof(attemptsNumber));
            Program.Log.Info($"Processing request for {ipAddress}");
            var res = await Result.OfAsync(async () =>
            {
                var request = WebRequest.CreateHttp(
                    Uri.EscapeUriString($"http://ip-api.com/json/{ipAddress}"));
                Task<string> requestTask = null;
                for (var i = 0; i < attemptsNumber; i++)
                {
                    requestTask = ProcessRequestAsync(request);
                    await Task.WhenAny(requestTask);
                    if (!requestTask.IsCompleted || requestTask.IsFaulted) 
                        continue;
                    break;
                }
                if (ExtractAdressInfo(ipAddress, requestTask, out var adressInfo)) 
                    return adressInfo;
    
                // ReSharper disable once PossibleNullReferenceException
                throw requestTask.Exception;
            });
            return res;
        }

        private static bool ExtractAdressInfo(IPAddress ipAddress, Task<string> requestTask, out AdressInfo adressInfo)
        {
            if (!requestTask.IsFaulted)
            {
                var responseContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestTask.Result);
                var isSuccessful = responseContent["status"] == "success";
                if (isSuccessful)
                {
                    adressInfo = new AdressInfo(ipAddress,
                        responseContent["country"],
                        responseContent["as"],
                        responseContent["isp"]);
                    return true;
                }

                throw new ArgumentException($"Unsuccessful request: {responseContent["message"]}");
            }

            adressInfo = null;
            return false;
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