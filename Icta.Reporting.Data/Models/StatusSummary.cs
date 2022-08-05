using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class StatusSummary : IModel
    {
        public string Status { get; set; }
        public int StatusTotal { get; set; }
        public int LastStatusTotal { get; set; }
    }
}
