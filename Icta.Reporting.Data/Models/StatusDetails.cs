using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class StatusDetails : IModel
    {
        public string Site { get; set; }
        public string LastStatus { get; set; }
        public string StatusReason { get; set; }
        public string StatusDate { get; set; }
    }
}
