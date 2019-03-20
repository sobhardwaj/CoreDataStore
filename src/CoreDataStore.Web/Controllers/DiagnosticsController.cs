using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using CoreDataStore.Web.Extensions;
using CoreDataStore.Web.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoreDataStore.Web.Controllers
{
    /// <summary>
    /// Server Status API Controller
    /// </summary>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class DiagnosticsController : Controller
    {
        private readonly IHostingEnvironment _env;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsController"/> class.
        /// </summary>
        /// <param name="env"></param>
        public DiagnosticsController(IHostingEnvironment env)
        {
            this._env = env;
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
        public IActionResult Get()
        {
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            var diagnostics = new ServerDiagnostics
            {
                MachineDate = DateTime.Now,
                MachineName = Environment.MachineName,
                MachineCulture = $"{CultureInfo.CurrentCulture.DisplayName} - {CultureInfo.CurrentCulture.Name}",

                Platform = osNameAndVersion.Trim(),
                DnsHostName = Dns.GetHostName(),
                WorkingDirectory = null,
                ContentRootPath = _env.ContentRootPath,
                WebRootPath = _env.WebRootPath,
                ApplicationName = _env.ApplicationName,
                EnvironmentName = _env.EnvironmentName,
                Runtime = GetNetCoreVersion(),
            };

            diagnostics.MachineTimeZone = TimeZoneInfo.Local.IsDaylightSavingTime(diagnostics.MachineDate) ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName;
            diagnostics.ApplicationVersionNumber = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            var ipAddresses = Dns.GetHostAddressesAsync(diagnostics.DnsHostName).Result.Where(x => x.AddressFamily == AddressFamily.InterNetwork).AsEnumerable().Distinct();

            var enumerable = ipAddresses as IPAddress[] ?? ipAddresses.ToArray();
            var ipList = new List<string>(enumerable.Count());
            foreach (var ipAddress in enumerable)
            {
                ipList.Add(ipAddress.ToString());
            }

            diagnostics.IpAddressList = ipList;

            return Ok(diagnostics);
        }

        private static string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }
    }
}
