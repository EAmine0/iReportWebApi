using Icta.Reporting.Data.Models;
using System.Collections.Generic;

namespace Icta.Reporting.Services.Interfaces
{
    public interface IIdentifiedSiteByCountryService
    {

        public IEnumerable<IdentifiedSiteByCountry> GetData();

    }
}
