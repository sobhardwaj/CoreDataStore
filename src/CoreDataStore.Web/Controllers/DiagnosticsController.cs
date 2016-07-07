using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Reflection;
using CoreDataStore.Web.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreDataStore.Web.Controllers
{

    /// <summary>
    /// Server Status API Controller
    /// Source: https://gist.github.com/sixeyed/8445048
    /// </summary>
    [Route("api/[controller]")]
    public class DiagnosticsController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAll")]
        public ServerDiagnostics Get()
        {
            var diagnostics = new ServerDiagnostics
            {
                MachineDate = DateTime.Now,
                MachineName = Environment.MachineName,
                MachineCulture =
                    string.Format("{0} - {1}", CultureInfo.CurrentCulture.DisplayName, CultureInfo.CurrentCulture.Name),
                DnsHostName = Dns.GetHostName(),
                //WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory, - NOT IN .NET CORE
                ApplicationName = "CoreDataStore",
            };

            diagnostics.MachineTimeZone = TimeZoneInfo.Local.IsDaylightSavingTime(diagnostics.MachineDate) ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName;
            diagnostics.ApplicationVersionNumber = GetType().GetTypeInfo().Assembly.GetName().Version.ToString();
            
            //Not Sure this works in Linux  

            //var ipHost = Dns.GetHostEntry(diagnostics.DnsHostName);
            //var ipList = new List<string>(ipHost.AddressList.Length);
            //foreach (var ipAddress in ipHost.AddressList)
            //{
            //    ipList.Add(ipAddress.ToString());
            //}
            //diagnostics.IpAddressList = ipList;

            diagnostics.IpAddressList = new List<string> {"XXX.XXX.XXX.1", "XXX.XXX.XXX.2", "XXX.XXX.XXX.3" };

            return diagnostics;
        }

        
    }
}
