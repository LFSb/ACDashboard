using System;
using ACDashboard.Resources;
using Microsoft.Phone.Controls;


namespace ACDashboard
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();
    }

    private void On_Click_Dashboard_Button(object sender, System.Windows.RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri(AppResources.DashboardUri, UriKind.Relative));
    }

    private void On_Click_Settings_Button(object sender, System.Windows.RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri(AppResources.SettingsUri, UriKind.Relative));
    }
  }
}