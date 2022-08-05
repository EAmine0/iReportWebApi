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
    public class DMeCRFDMQueriesController : ControllerBase
    {
        private readonly IDMeCRFDMQueriesService _dmecrfDmQueries;

        public DMeCRFDMQueriesController(IDMeCRFDMQueriesService dmecrfDmQueries)
        {
            _dmecrfDmQueries = dmecrfDmQueries;
        }

        [HttpGet]
        [Route("DMeCRFDMQueries")]
        public IEnumerable<DMeCRFDMQueries> GetAPI()
        {
            return _dmecrfDmQueries.GetData();
        }
    }
}
