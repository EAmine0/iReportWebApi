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
    public class MonitoringController : ControllerBase
    {
        private readonly IMonitoringService _monitoring;

        public MonitoringController(IMonitoringService monitoring)
        {
            _monitoring = monitoring;
        }

        [HttpGet]
        [Route("curveOfInclusion")]
        public IEnumerable<Monitoring> GetCurveOfInclusions()
        {
            return _monitoring.GetData();
        }
    }
}
