using Icta.Reporting.Data.Models;
using Icta.Reporting.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icta.Reporting.WebApi.Controllers.Reports
{
    [ApiController]
    [Route("api/reports/[controller]s")]
    public class DMCRFVisitsController : ControllerBase
    {
        private readonly IDMCRFVisitsService _dmcrfVisits;

        public DMCRFVisitsController(IDMCRFVisitsService dmcrfVisits)
        {
            _dmcrfVisits = dmcrfVisits;
        }

        [HttpGet]
        [Route("DMCRFVisits")]
        public IEnumerable<DMCRFVisits> GetCurveOfInclusions()
        {
            return _dmcrfVisits.GetData();
        }
    }
}
