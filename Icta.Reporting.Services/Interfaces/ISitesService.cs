using Icta.Reporting.Data.Models;
using System.Collections.Generic;

namespace Icta.Reporting.Services.Interfaces
{
    public interface ISitesService
    {
        public IEnumerable<Sites> GetData();
    }
}
