using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class ActivitiesMonitoring : IModel
    {
        public string division_domain { get; set; }
        public string site { get; set; }
        public string site_status { get; set; }
        public string financial_agreement { get; set; }
        public string selected_date { get; set; }
        public string readyToInclude_date { get; set; }
        public string firstMonitoring_date { get; set; }
        public string lastMonitoring_date { get; set; }
        public string closeOut_date { get; set; }
        public int nb_monitoring { get; set; }
    }
}
