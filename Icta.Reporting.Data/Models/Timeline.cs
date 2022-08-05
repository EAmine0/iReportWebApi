using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class Timeline : IModel
    {
        public string phase { get; set; }
        public string milestone { get; set; }
        public string pre_date { get; set; }
        public string date { get; set; }
        public string post_date { get; set; }
    }
}
