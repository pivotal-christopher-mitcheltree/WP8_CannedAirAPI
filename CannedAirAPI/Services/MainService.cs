using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CannedAirAPI.Models;
using Newtonsoft.Json;

namespace CannedAirAPI.Services
{
    public interface IMainService
    {
        Task<string> GetFromUri(string uriString, Dictionary<string, string> headers);
    }
    class MainService : IMainService
    {
        public async Task<string> GetFromUri(string uriString, Dictionary<string, string> headers)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uriString);

                if (headers.ContainsKey("username") && headers.ContainsKey("password") && headers.ContainsKey("environment"))
                {
                    request.Headers.Add("X-Cannedair-Username", headers["username"]);
                    request.Headers.Add("X-Cannedair-Password", headers["password"]);
                    request.Headers.Add("X-Cannedair-Environment", headers["environment"]);
                    //request.Headers.Add("Host", String.Empty);
                    //request.Headers.Add("Cookie", String.Empty);
                }
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Message :{0} ", e.Message);
                return String.Empty;
            }
        }
    }
}
