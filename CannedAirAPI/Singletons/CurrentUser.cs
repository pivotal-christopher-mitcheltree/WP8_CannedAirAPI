using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedAirAPI.Singletons
{
    public class CurrentUser
    {
        private static CurrentUser instance;

        private readonly string _password;
        private readonly string _userName;
        private readonly string _openAirId;
        private readonly string _roleId;

        private CurrentUser(string userName, string password, string openAirId, string roleId)
        {
            _userName = userName;
            _password = password;
            _openAirId = openAirId;
            _roleId = roleId;
        }

        public static void Initialize(string username, string password, string openAirId, string roleId)
        {
             instance = new CurrentUser(username, password, openAirId, roleId);
        }

        public static CurrentUser GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("Please initialize current user!");
            }
            else
            {
                return instance;
            }
        }

        public string GetUserName
        {
            get { return _userName; }
        }

        public string GetPassword
        {
            get { return _password; }
        }

        public string GetOpenAirId
        {
            get { return _openAirId; }
        }

        public string GetRoleId
        {
            get { return _roleId; }
        }
    }
}
