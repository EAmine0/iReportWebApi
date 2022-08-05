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
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineService _timeline;

        public TimelineController(ITimelineService timeline)
        {
            _timeline = timeline;
        }

        [HttpGet]
        [Route("Timeline")]
        public IEnumerable<Timeline> GetAPI()
        {
            return _timeline.GetData();
        }
    }
}
