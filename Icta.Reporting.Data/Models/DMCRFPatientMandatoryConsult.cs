using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMCRFPatientMandatoryConsult : IModel
    {
        public string Label { get; set; }
        public int NA { get; set; }
        public int Incomplete { get; set; }
        public int Complete { get; set; }
        public int DEA { get; set; }
        public int DEB { get; set; }
        public int Clean { get; set; }
    }
}
