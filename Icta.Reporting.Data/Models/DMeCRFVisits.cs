using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMeCRFVisits : IModel
    {
        public float DataEntry { get; set; }
        public float Signed { get; set; }
    }
}
