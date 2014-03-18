using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CannedAirAPI.Models;
using CannedAirAPI.Singletons;
using Newtonsoft.Json;

namespace CannedAirAPI.Services
{
    public interface IMainService
    {
        Task<string> GetTimesheets(string uriString);
    }
    class MainService : IMainService
    {
        public async Task<string> GetTimesheets(string uriString)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uriString);
                
                request.Headers.Add("X-Cannedair-Username", CurrentUser.Instance.Username);
                request.Headers.Add("X-Cannedair-Password", CurrentUser.Instance.Password);
                request.Headers.Add("X-Cannedair-Environment", "sandbox"); // TODO: make better
                
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
