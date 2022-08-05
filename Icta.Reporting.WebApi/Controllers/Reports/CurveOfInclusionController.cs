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
    public class CurveOfInclusionController : ControllerBase
    {
        private readonly ICurveOfInclusionService _curveOfInclusion;

        public CurveOfInclusionController(ICurveOfInclusionService curveOfInclusion)
        {
            _curveOfInclusion = curveOfInclusion;
        }

        [HttpGet]
        [Route("curveOfInclusion")]
        public IEnumerable<CurveOfInclusion> GetAPI()
        {
            return _curveOfInclusion.GetData();
        }
    }
}
