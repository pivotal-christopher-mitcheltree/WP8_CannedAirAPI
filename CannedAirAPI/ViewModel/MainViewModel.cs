using System.Collections.Generic;
using CannedAirAPI.Services;
using GalaSoft.MvvmLight;

namespace CannedAirAPI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ILoginService _loginservice; 
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILoginService loginservice)
        {
            _loginservice = loginservice;
            UserLogin();
        }

        public void UserLogin()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("username", "gweresch" );
            headers.Add("password", "password");
            headers.Add("environment", "sandbox");
            const string url = "http://cannedair-staging.cfapps.io/v1/login";
            _loginservice.GetFromUri(url, headers);
        }
    }
}