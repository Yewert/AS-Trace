using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace AS_Route
{
    public class TracertTracer : ITracer
    {
        private static readonly Regex TracertTablePattern = 
            new Regex(@"^\s*\d+(?:\s*\d+\s*ms){3}\s*.*?(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}).*" );
        public IEnumerable<string> GetOutputAndAdresses(string address, int maxHops = 30)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c tracert -h {maxHops} {address}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            while (!process.StandardOutput.EndOfStream) {
                var line = process.StandardOutput.ReadLine();
                yield return line;
            }
            
            process.WaitForExit();
        }
        
        public bool TryParseIP(string output_line, out IPAddress ipAddress)
        {
            var match = TracertTablePattern.Match(output_line ?? throw new Exception());
            if (match.Success)
            {
                var ip = match.Groups[1].Value;
                ipAddress = IPAddress.Parse(ip);
                return true;
            }

            ipAddress = null;
            return false;
        }
    }
}