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
    public class SafetyAEController : ControllerBase
    {
        private readonly ISafetyAEService _safetyAE;

        public SafetyAEController(ISafetyAEService safetyAE)
        {
            _safetyAE = safetyAE;
        }

        [HttpGet]
        [Route("SafetyAE")]
        public IEnumerable<SafetyAE> GetAPI()
        {
            return _safetyAE.GetData();
        }
    }
}
