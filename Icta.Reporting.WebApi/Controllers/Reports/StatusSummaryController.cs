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
    public class StatusSummaryController : ControllerBase
    {
        private readonly IStatusSummaryService _statusSummary;

        public StatusSummaryController(IStatusSummaryService statusSummary)
        {
            _statusSummary = statusSummary;
        }

        [HttpGet]
        [Route("StatusSummary")]
        public IEnumerable<StatusSummary> GetAPI()
        {
            return _statusSummary.GetData();
        }
    }
}
