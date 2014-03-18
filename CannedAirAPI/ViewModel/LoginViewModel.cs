using System;
using System.Collections.Generic;
using CannedAirAPI.Models;
using CannedAirAPI.Services;
using CannedAirAPI.Singletons;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

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
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService _loginservice; 
        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel(ILoginService loginservice)
        {
            _loginservice = loginservice;
        }

        private string _username = "tnandakumaran";
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }

        private string _password = "password";
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        private int _isInvalidLogin;
        public int IsInvalidLogin
        {
            get { return _isInvalidLogin; }
            set
            {
                _isInvalidLogin = value;
                RaisePropertyChanged("IsInvalidLogin");
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public async void UserLogin()
        {
            IsLoading = true;
            var headers = new Dictionary<string, string>();
            headers.Add("username", Username );
            headers.Add("password", Password);
            headers.Add("environment", "sandbox");
            const string url = "http://cannedair-staging.cfapps.io/v1/login";
            var response = await _loginservice.GetFromUri(url, headers);
            if (!String.IsNullOrEmpty(response))
            {
                IsInvalidLogin = 0;
                var loginResponse = JsonConvert.DeserializeObject<Login>(response);
                CurrentUser.Initialize(headers["username"], headers["password"], loginResponse.OpenAirId, loginResponse.RoleId);
            }
            else
            {
                IsInvalidLogin = 1;
            }
            IsLoading = false;
        }
    }
}