using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMeCRFDMQueries : IModel
    {
        public string Label { get; set; }
        public int Issued { get; set; }
        public int Closed { get; set; }
        public int Sent { get; set; }
        public int Received { get; set; }
        public int Completed { get; set; }
        public int Confirmed { get; set; }
        public int Resolved { get; set; }
    }
}
