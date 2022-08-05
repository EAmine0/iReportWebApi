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
    public class DMCRFPatientCleanedController : ControllerBase
    {
        private readonly IDMCRFPatientCleanedService _dmcrfPatientCleaned;

        public DMCRFPatientCleanedController(IDMCRFPatientCleanedService dmcrfPatientCleaned)
        {
            _dmcrfPatientCleaned = dmcrfPatientCleaned;
        }

        [HttpGet]
        [Route("DMCRFPatientCleaned")]
        public IEnumerable<DMCRFPatientCleaned> GetCurveOfInclusions()
        {
            return _dmcrfPatientCleaned.GetData();
        }
    }
}
