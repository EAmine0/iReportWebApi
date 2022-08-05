using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class DocumentConformity : IModel
    {
        public string NoYes { get; set; }
        public int Value { get; set; }
        public int Received { get; set; }
        public int DefaultUnresolved { get; set; }
    }
}
