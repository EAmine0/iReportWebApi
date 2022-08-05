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
    public class StatusDetailsController : ControllerBase
    {
        private readonly IStatusDetailsService _statusDetails;

        public StatusDetailsController(IStatusDetailsService statusDetails)
        {
            _statusDetails = statusDetails;
        }

        [HttpGet]
        [Route("StatusDetails")]
        public IEnumerable<StatusDetails> GetAPI()
        {
            return _statusDetails.GetData();
        }
    }
}
