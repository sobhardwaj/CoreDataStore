using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Reflection;
using CoreDataStore.Web.Extensions;
using CoreDataStore.Web.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net.Sockets;

namespace CoreDataStore.Web.Controllers
{

    /// <summary>
    /// Server Status API Controller
    /// </summary>
    /// 
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class DiagnosticsController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public DiagnosticsController(IHostingEnvironment env, IConfiguration configuration)
        {
            this._env = env;
            this._configuration = configuration;
        }


        /// <summary>
        ///  Heartbeat
        /// </summary>
        /// <returns></returns>
        [HttpGet("status")]
        public IActionResult Status() => Ok();


        /// <summary>
        ///  Get Server Diagnostics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ServerDiagnostics), 200)]
        [Produces("application/json", Type = typeof(ServerDiagnostics))]
        public ServerDiagnostics Get()
        {
            var diagnostics = new ServerDiagnostics
            {
                MachineDate = DateTime.Now,
                MachineName = Environment.MachineName,
                MachineCulture =
                    string.Format("{0} - {1}", CultureInfo.CurrentCulture.DisplayName, CultureInfo.CurrentCulture.Name),

                Platform = PlatformHandler.Platform.OSPlatform.ToString(),
                DnsHostName = Dns.GetHostName(),
                WorkingDirectory = null,
                ContentRootPath = _env.ContentRootPath,
                WebRootPath = _env.WebRootPath,
                ApplicationName = _env.ApplicationName,
                EnvironmentName = _env.EnvironmentName,
            };

            diagnostics.MachineTimeZone = TimeZoneInfo.Local.IsDaylightSavingTime(diagnostics.MachineDate) ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName;
            diagnostics.ApplicationVersionNumber = GetType().GetTypeInfo().Assembly.GetName().Version.ToString();

            var ipAddresses = Dns.GetHostAddressesAsync(diagnostics.DnsHostName).Result.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList().Distinct();

            var enumerable = ipAddresses as IPAddress[] ?? ipAddresses.ToArray();
            var ipList = new List<string>(enumerable.Count());
            foreach (var ipAddress in enumerable)
            {
                ipList.Add(ipAddress.ToString());
            }

            diagnostics.IpAddressList = ipList;

            return diagnostics;
        }
    }
}
