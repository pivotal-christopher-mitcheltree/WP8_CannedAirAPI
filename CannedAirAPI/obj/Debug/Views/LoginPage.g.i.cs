﻿#pragma checksum "C:\Users\dx169-xl\Documents\Visual Studio 2013\Projects\CannedAirAPI\CannedAirAPI\Views\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "776519B88910F4BBB057C180C71D6609"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class LoginPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid LoginGrid;
        
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        internal System.Windows.Controls.PasswordBox PasswordTextBox;
        
        internal System.Windows.Controls.TextBlock ErrorMessageTextBlock;
        
        internal System.Windows.Controls.Button LoginButton;
        
        internal System.Windows.Controls.ProgressBar Bar;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/CannedAirAPI;component/Views/LoginPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.LoginGrid = ((System.Windows.Controls.Grid)(this.FindName("LoginGrid")));
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(this.FindName("UsernameTextBox")));
            this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(this.FindName("PasswordTextBox")));
            this.ErrorMessageTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("ErrorMessageTextBlock")));
            this.LoginButton = ((System.Windows.Controls.Button)(this.FindName("LoginButton")));
            this.Bar = ((System.Windows.Controls.ProgressBar)(this.FindName("Bar")));
        }
    }
}

