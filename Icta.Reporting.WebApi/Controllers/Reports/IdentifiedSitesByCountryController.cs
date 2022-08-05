using Icta.Reporting.Data.Models;
using Icta.Reporting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Icta.Reporting.WebApi.Controllers.Reports
{

    [ApiController]
    [Route("api/reports/[controller]s")]
    public class IdentifiedSitesByCountryController : ControllerBase
    {
        private readonly IIdentifiedSiteByCountryService _identifiedSiteByCountryService;

        public IdentifiedSitesByCountryController(IIdentifiedSiteByCountryService identifiedSiteByCountryService)
        {
            _identifiedSiteByCountryService = identifiedSiteByCountryService;
        }

        [HttpGet]
        [Route("identifiedSitesByCountry")]
        public IEnumerable<IdentifiedSiteByCountry> GetIdentifiedSitesByCountry()
        {
            return _identifiedSiteByCountryService.GetData();
        }

    }
}
