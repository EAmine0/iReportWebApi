using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMCRFDMQueries : IModel
    {
        public string label { get; set; }
        public int issued { get; set; }
        public int closed { get; set; }
        public int sent { get; set; }
        public int received { get; set; }
        public int completed { get; set; }
        public int confirmed { get; set; }
        public int resolved { get; set; }
    }
}
