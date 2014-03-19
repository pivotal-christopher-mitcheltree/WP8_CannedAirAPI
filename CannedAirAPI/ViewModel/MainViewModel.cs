using System;
using System.Collections.Generic;
using System.Linq;
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

        private TimesheetWeek _previousTimesheet;
        public TimesheetWeek PreviousTimesheet
        {
            get { return _previousTimesheet; }
            set
            {
                _previousTimesheet = value;
                RaisePropertyChanged("PreviousTimesheet");
            }
        }

        private TimesheetWeek _currentTimesheet;
        public TimesheetWeek CurrentTimesheet
        {
            get { return _currentTimesheet; }
            set
            {
                _currentTimesheet = value;
                RaisePropertyChanged("CurrentTimesheet");
            }
        }

        private TimesheetWeek _nextTimesheet;
        public TimesheetWeek NextTimesheet
        {
            get { return _nextTimesheet; }
            set
            {
                _nextTimesheet = value;
                RaisePropertyChanged("NextTimesheet");
            }
        }

        private List<Timesheet> _timesheets = new List<Timesheet>();
        public List<Timesheet> Timesheets
        {
            get { return _timesheets; }
            set
            {
                _timesheets = value;
                PreviousTimesheet = new TimesheetWeek(_timesheets[0]);
                CurrentTimesheet = new TimesheetWeek(_timesheets[1]);
                NextTimesheet = new TimesheetWeek(_timesheets[2]);
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

            var url = String.Format("http://cannedair-staging.cfapps.io/v1/users/{0}/timesheets?starts_at={1}&ends_at={2}", CurrentUser.Instance.OpenAirId, "2013-11-18", "2013-12-25"); //startsAt, endsAt); TODO: Fix!

            IsLoading = true;
            var response = await _mainservice.GetTimesheets(url);
            var tmpList = new List<Timesheet>();
            if (!String.IsNullOrEmpty(response))
            {
                var responseJsonArray = JArray.Parse(response);
                foreach (var timesheet in responseJsonArray)
                {
                    if (tmpList.Count == 3)
                    {
                        break;
                    }
                    tmpList.Add(JsonConvert.DeserializeObject<Timesheet>(timesheet.ToString()));
                }
                while (tmpList.Count < 3)
                {
                    var emptyTimesheet = new Timesheet {UserId = String.Empty, Id = String.Empty, StartsAt = String.Empty, EndsAt = String.Empty, Tasks = new List<Task>()};
                    tmpList.Add(emptyTimesheet);
                }
                Timesheets = tmpList;
            }
            else
            {
                // TODO: failure
            }
            IsLoading = false;
        }

        public class TimesheetWeek
        {
            public Timesheet OriginalTimesheet { get; set; }
            public Dictionary<string, Day> Days;

            public List<string> KeyList { get; set; } //
            public List<Day> ValueList { get; set; } //
            
            public TimesheetWeek(Timesheet timesheet)
            {
                InitializeDaysDictionary();
                OriginalTimesheet = timesheet;
                
                KeyList = new List<string>(); //
                ValueList = new List<Day>(); //

                foreach (var task in timesheet.Tasks)
                {
                    var day = Convert.ToDateTime(task.Date).DayOfWeek.ToString().ToLower();
                    if (Days.ContainsKey(day))
                    {
                        Days[day].TotalHours += Convert.ToDouble(task.Hours);
                        Days[day].Tasks.Add(task);
                    }
                }

                KeyList = Days.Keys.ToList(); //
                ValueList = Days.Values.ToList(); //
            }

            private void InitializeDaysDictionary()
            {
                Days = new Dictionary<string, Day>
                {
                    {"monday", new Day()},
                    {"tuesday", new Day()},
                    {"wednesday", new Day()},
                    {"thursday", new Day()},
                    {"friday", new Day()},
                    {"saturday", new Day()},
                    {"sunday", new Day()}
                };
            }

            public class Day // TODO: accessor?
            {
                public Day()
                {
                    Tasks = new List<Task>();
                    TotalHours = 0;
                    Date = String.Empty;
                }
                public string Date { get; set; }
                public double TotalHours { get; set; }
                public List<Task> Tasks { get; set; }
            }
        }
    }
}