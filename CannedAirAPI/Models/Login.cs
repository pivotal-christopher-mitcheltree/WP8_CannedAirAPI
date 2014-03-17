using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CannedAirAPI.Models
{
    public class Login
    {
        [JsonProperty(PropertyName = "openair_id")]
        public string OpenAirId { get; set; }

        [JsonProperty(PropertyName = "role_id")]
        public string RoleId { get; set; }
    }
}
