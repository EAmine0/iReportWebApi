using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class Monitoring : IModel
    {
        public string Nature { get; set; }
        public string Mode { get; set; }
        public int LastStatus { get; set; }
        public float AvgMonitoringPerSite { get; set; }
    }
}
