using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows.Controls;
using ACDashboard.DashboardHelpers;
using ACDashboard.Models;
using ACDashboard.Resources;
using Microsoft.Phone.Controls;

namespace ACDashboard.Views
{
  public partial class Settings : PhoneApplicationPage
  {
    private IsolatedStorageSettings appSettings;

    private SettingsModel _settings;

    public Settings()
    {
      InitializeComponent();
      LoadSettings();
    }

    #region Load Settings
    private void LoadSettings()
    {
      InitializeSettings();

      HostIPTextBox.Text = _settings.HostIp;

      Picker.ItemsSource = WebRequestHelper.LoadDashboardTypes(_settings.HostIp);
    }
    #endregion

    #region Init
    private void InitializeSettings()
    {
      appSettings = IsolatedStorageSettings.ApplicationSettings;
      _settings = new SettingsModel
      {
        HostIp = appSettings.Contains(AppResources.HostIPSettingName) ? appSettings[AppResources.HostIPSettingName].ToString() : AppResources.HostIPSettingPlaceHolder,
        DashboardName = appSettings.Contains(AppResources.DashboardSettingName) ? appSettings[AppResources.DashboardSettingName].ToString() : String.Empty
      };
    }
    #endregion

    #region UI Event handlers
    private void OnSaveButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
      if (appSettings.Contains(AppResources.HostIPSettingName))
        appSettings[AppResources.HostIPSettingName] = HostIPTextBox.Text;
      else
        appSettings.Add(AppResources.HostIPSettingName, HostIPTextBox.Text);
      InitializeSettings();
      Picker.ItemsSource = WebRequestHelper.LoadDashboardTypes(_settings.HostIp);
    }

    private void OnPickerSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //TODO: Add implementation.
    }
    #endregion
  }
}