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
    public class DMeCRFVisitsController : ControllerBase
    {
        private readonly IDMeCRFVisitsService _dmecrfVisits;

        public DMeCRFVisitsController(IDMeCRFVisitsService dmecrfVisits)
        {
            _dmecrfVisits = dmecrfVisits;
        }

        [HttpGet]
        [Route("DMeCRFVisits")]
        public IEnumerable<DMeCRFVisits> GetAPI()
        {
            return _dmecrfVisits.GetData();
        }
    }
}
