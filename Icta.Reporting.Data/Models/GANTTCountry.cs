using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Data.Models
{
    public class GANTTCountry : IModel
    {
        public string country { get; set; }
        public string regulatory_start_date_planned { get; set; }
        public string regulatory_end_date_planned { get; set; }
        public string regulatory_start_date_actual { get; set; }
        public string regulatory_end_date_actual { get; set; }

        public string startup_start_date_planned { get; set; }
        public string startup_end_date_planned { get; set; }
        public string startup_start_date_actual { get; set; }
        public string startup_end_date_actual { get; set; }

        public string coredocs_start_date_planned { get; set; }
        public string coredocs_end_date_planned { get; set; }
        public string coredocs_start_date_actual { get; set; }
        public string coredocs_end_date_actual { get; set; }

        public string siteselection_start_date_planned { get; set; }
        public string siteselection_end_date_planned { get; set; }
        public string siteselection_start_date_actual { get; set; }
        public string siteselection_end_date_actual { get; set; }

        public string initiation_start_date_planned { get; set; }
        public string initiation_end_date_planned { get; set; }
        public string initiation_start_date_actual { get; set; }
        public string initiation_end_date_actual { get; set; }

        public string recruitment_start_date_planned { get; set; }
        public string recruitment_end_date_planned { get; set; }
        public string recruitment_start_date_actual { get; set; }
        public string recruitment_end_date_actual { get; set; }

        public string monitoring_start_date_planned { get; set; }
        public string monitoring_end_date_planned { get; set; }
        public string monitoring_start_date_actual { get; set; }
        public string monitoring_end_date_actual { get; set; }
    }
}
