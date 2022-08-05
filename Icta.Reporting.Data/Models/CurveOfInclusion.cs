using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class CurveOfInclusion : IModel
    {
        public string date { get; set; }
        public int included { get; set; }
        public int randomised { get; set; }
        public int theoretical { get; set; }
    }
}
