using Icta.Reporting.Data.Interfaces;

namespace Icta.Reporting.Data.Models
{
    public class IdentifiedSiteByCountry : IModel
    {

        public string Country { get; set; }
        public int SiteIdentified { get; set; }

    }
}
