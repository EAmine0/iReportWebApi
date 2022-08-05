using Icta.Reporting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Services.Interfaces
{
    public interface IDMeCRFVisitsService
    {
        public IEnumerable<DMeCRFVisits> GetData();
    }
}
