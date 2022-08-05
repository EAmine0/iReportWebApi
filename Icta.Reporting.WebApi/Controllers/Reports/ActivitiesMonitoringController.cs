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
    public class ActivitiesMonitoringController : ControllerBase
    {
        private readonly IActivitiesMonitoringService _activitiesMonitoring;

        public ActivitiesMonitoringController(IActivitiesMonitoringService activitiesMonitoring)
        {
            _activitiesMonitoring = activitiesMonitoring;
        }

        [HttpGet]
        [Route("ActivitiesMonitoring")]
        public IEnumerable<ActivitiesMonitoring> GetAPI()
        {
            return _activitiesMonitoring.GetData();
        }
    }
}
