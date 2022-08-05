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
    public class DMCRFDMQueriesController : ControllerBase
    {
        private readonly IDMCRFDMQueriesService _dmcrfDmQueries;

        public DMCRFDMQueriesController(IDMCRFDMQueriesService dmcrfDmQueries)
        {
            _dmcrfDmQueries = dmcrfDmQueries;
        }

        [HttpGet]
        [Route("DMCRFDMQueries")]
        public IEnumerable<DMCRFDMQueries> GetAPI()
        {
            return _dmcrfDmQueries.GetData();
        }
    }
}
