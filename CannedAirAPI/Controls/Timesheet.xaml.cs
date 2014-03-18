using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CannedAirAPI.Controls
{
    public partial class Timesheet : UserControl
    {
        public Timesheet()
        {
            InitializeComponent();
        }

        private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Timesheet_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dataContext = this.DataContext as Timesheet;
        }
    }
}
