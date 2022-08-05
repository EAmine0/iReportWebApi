using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DMeCRFPatientMandatoryConsult : IModel
    {
        public string Label { get; set; }
        public int Expected { get; set; }
        public int InProgress { get; set; }
        public int DataEntry { get; set; }
        public int Signed { get; set; }
    }
}
