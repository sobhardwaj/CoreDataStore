using System;
using System.Collections.Generic;

namespace CoreDataStore.Web.ViewModels
{
    public class ServerDiagnostics
    {
        public string ApplicationName { get; set; }

        public string ApplicationVersionNumber { get; set; }

        public string Status { get; set; }

        public string EnvironmentName { get; set; }

        public string Platform { get; set; }

        public string WorkingDirectory { get; set; }

        public string ContentRootPath { get; set; }

        public string WebRootPath { get; set; }

        public string DnsHostName { get; set; }

        public string MachineName { get; set; }

        public DateTime MachineDate { get; set; }

        public string MachineCulture { get; set; }

        public string MachineTimeZone { get; set; }

        public IEnumerable<string> IpAddressList { get; set; }

        public IEnumerable<DiagnosticCheckCollection> Checks { get; set; }

    }
}
