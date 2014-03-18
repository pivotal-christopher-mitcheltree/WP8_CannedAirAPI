using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedAirAPI.Singletons
{
    public class CurrentUser
    {
        //make the instance of itself public. We do not need a GetInstance
        public static CurrentUser Instance;
        private static bool _hasUserBeenInitialized;

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string OpenAirId { get; private set; }
        public string RoleId { get; private set; }

        //constructor should not take params
        private CurrentUser() {}

        public static void Initialize(string username, string password, string openAirId, string roleId)
        {
            if (_hasUserBeenInitialized) return;
            Instance = new CurrentUser
            {
                Username = username,
                Password = password,
                OpenAirId = openAirId,
                RoleId = roleId,
            };
            _hasUserBeenInitialized = true;
        }
    }
}
