using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMCRFVisits : IModel
    {
        public float Entered { get; set; }
        public float Cleaned { get; set; }
    }
}
