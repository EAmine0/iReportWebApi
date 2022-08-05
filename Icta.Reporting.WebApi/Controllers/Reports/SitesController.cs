using Icta.Reporting.Data.Models;
using Icta.Reporting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icta.Reporting.WebApi.Controllers.Reports
{
    [ApiController]
    [Route("api/reports/[controller]s")]
    public class SitesController : ControllerBase
    {
        private readonly ISitesService _sites;

        public SitesController(ISitesService sites)
        {
            _sites = sites;
        }

        [HttpGet]
        [Route("sites")]
        public IEnumerable<Sites> GetIdentifiedSitesByCountry()
        {
            return _sites.GetData();
        }
    }
}
