using System;
using System.Collections.Generic;
using CannedAirAPI.Models;
using CannedAirAPI.Services;
using CannedAirAPI.Singletons;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        private readonly IMainService _mainservice;

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

        private List<Timesheet> _timesheets = new List<Timesheet>();
        public List<Timesheet> Timesheets
        {
            get { return _timesheets; }
            set
            {
                _timesheets = value;
                RaisePropertyChanged("Timesheets");
            }
        }

        public MainViewModel(IMainService mainservice)
        {
            _mainservice = mainservice;
            GetTimesheets();
        }

        private async void GetTimesheets()
        {
            var currentDate = DateTime.Now;
            var previousDate = currentDate.AddDays(-7);
            var nextDate = currentDate.AddDays(7);

            var startsAt = previousDate.Year + "-" + previousDate.Month + "-" + previousDate.Day;
            var endsAt = nextDate.Year + "-" + nextDate.Month + "-" + nextDate.Day;

            var url = String.Format("http://cannedair-staging.cfapps.io/v1/users/{0}/timesheets?starts_at={1}&ends_at={2}", CurrentUser.Instance.OpenAirId, "2013-11-18", "2013-12-5"); //startsAt, endsAt); TODO: Fix!

            IsLoading = true;
            var response = await _mainservice.GetTimesheets(url);
            if (!String.IsNullOrEmpty(response))
            {
                var responseJsonArray = JArray.Parse(response);
                foreach (var timesheet in responseJsonArray)
                {
                    Timesheets.Add(JsonConvert.DeserializeObject<Timesheet>(timesheet.ToString()));
                }
//                var loginResponse = JsonConvert.DeserializeObject<Login>(response);
//                CurrentUser.Initialize(headers["username"], headers["password"], loginResponse.OpenAirId, loginResponse.RoleId);
            }
            else
            {
                // TODO: failure
            }
            IsLoading = false;
        }
    }
}