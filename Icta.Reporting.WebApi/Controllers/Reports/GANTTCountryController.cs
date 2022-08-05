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
    public class GANTTCountryController : ControllerBase
    {
        private readonly IGANTTCountryService _ganttCountry;

        public GANTTCountryController(IGANTTCountryService ganttCountry)
        {
            _ganttCountry = ganttCountry;
        }

        [HttpGet]
        [Route("GANTTCountry")]
        public IEnumerable<GANTTCountry> GetAPI()
        {
            return _ganttCountry.GetData();
        }
    }
}
