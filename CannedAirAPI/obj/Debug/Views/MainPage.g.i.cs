﻿#pragma checksum "C:\Users\dx169-xl\Documents\Visual Studio 2013\Projects\CannedAirAPI\CannedAirAPI\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "43EFC3140B1AE58E8553CB16E384ECF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CannedAirAPI.Controls;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace CannedAirAPI.Views {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid CurrentWeekGrid;
        
        internal CannedAirAPI.Controls.Timesheet CurrentWeekTimesheet;
        
        internal System.Windows.Controls.ProgressBar CurrentWeekProgressBar;
        
        internal System.Windows.Controls.Grid NextWeekGrid;
        
        internal CannedAirAPI.Controls.Timesheet NextWeekTimesheet;
        
        internal System.Windows.Controls.ProgressBar NextWeekProgressBar;
        
        internal System.Windows.Controls.Grid PreviousWeekGrid;
        
        internal CannedAirAPI.Controls.Timesheet PreviousWeekTimesheet;
        
        internal System.Windows.Controls.ProgressBar PreviousWeekProgressBar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/CannedAirAPI;component/Views/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.CurrentWeekGrid = ((System.Windows.Controls.Grid)(this.FindName("CurrentWeekGrid")));
            this.CurrentWeekTimesheet = ((CannedAirAPI.Controls.Timesheet)(this.FindName("CurrentWeekTimesheet")));
            this.CurrentWeekProgressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("CurrentWeekProgressBar")));
            this.NextWeekGrid = ((System.Windows.Controls.Grid)(this.FindName("NextWeekGrid")));
            this.NextWeekTimesheet = ((CannedAirAPI.Controls.Timesheet)(this.FindName("NextWeekTimesheet")));
            this.NextWeekProgressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("NextWeekProgressBar")));
            this.PreviousWeekGrid = ((System.Windows.Controls.Grid)(this.FindName("PreviousWeekGrid")));
            this.PreviousWeekTimesheet = ((CannedAirAPI.Controls.Timesheet)(this.FindName("PreviousWeekTimesheet")));
            this.PreviousWeekProgressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("PreviousWeekProgressBar")));
        }
    }
}

