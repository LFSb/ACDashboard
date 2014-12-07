using System;
using System.Net;
using System.Collections.Generic;

namespace ACDashboard.DashboardHelpers
{
  public static class WebRequestHelper
  {
    private static List<String> _returnList;
    private static String _hostIp;

    public static IEnumerable<String> LoadDashboardTypes(String hostIp)
    {
      Init(hostIp);

      try
      {
        var request = (HttpWebRequest)WebRequest.Create(new Uri(hostIp));
        request.BeginGetRequestStream(LoadDashboardTypesCallBack, request);
      }
      catch (Exception e)
      {
        _returnList.Add(String.Format("Unable to get response from: {0}. {1} Errormessage: {2}", hostIp, Environment.NewLine, e.Message));
      }

      return _returnList;
    }

    private static void Init(String hostIp)
    {
      _returnList = new List<String>();
      _hostIp = hostIp;
    }
    private static void LoadDashboardTypesCallBack(IAsyncResult result)
    {
      var request = result.AsyncState as HttpWebRequest;
      if (request != null)
      {
        try
        {
          var response = request.EndGetResponse(result);
          
        }
        catch (WebException e)
        {
          _returnList.Clear();
          _returnList.Add(String.Format("Something went wrong while getting the dashboardtypes from {0}. Error: {1}", _hostIp, e.Message));
        }
      }
    }
  }
}
