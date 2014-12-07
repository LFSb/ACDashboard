using System;
using ACDashboard.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ACDashboard.Views
{
  public partial class Dashboard : PhoneApplicationPage
  {
    private SettingsModel _settings;

    public Dashboard()
    {
      InitializeComponent();
      LoadSettings();
      Browser.IsScriptEnabled = true;
      PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
      Browser.Navigate(new Uri("http://192.168.1.120:9090/MoTeC%20Mini%20Dash%20Display%20-%20MDD/index.html", UriKind.Absolute));
    }

    private void LoadSettings()
    {
      
    }
  }
}