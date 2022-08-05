using Icta.Reporting.Data.Models;
using Icta.Reporting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Icta.Reporting.WebApi.Controllers.Reports
{

    [ApiController]
    [Route("api/reports/[controller]s")]
    public class SiteStatusController
    {
        private readonly ISiteStatusService _siteStatusService;

        public SiteStatusController(ISiteStatusService siteStatusService)
        {
            _siteStatusService = siteStatusService;
        }

        [HttpGet]
        [Route("SiteStatus")]
        public IEnumerable<SiteStatus> GetSiteStatus()
        {
            return _siteStatusService.GetData();
        }

    }
}
