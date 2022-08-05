using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class SafetyAE : IModel
    {
        public string InitialFollowUP { get; set; }
        public int Value { get; set; }
        public int Value2 { get; set; }
        public int AckNotReceived { get; set; }
    }
}
