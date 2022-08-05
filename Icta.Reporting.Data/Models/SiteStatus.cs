using Icta.Reporting.Data.Interfaces;

namespace Icta.Reporting.Data.Models
{
    public class SiteStatus : IModel
    {

        public string Label { get; set; }
        public int StatusTotal { get; set; }
        public int LastStatusTotal { get; set; }

    }
}
