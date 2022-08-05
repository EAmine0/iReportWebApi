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
    public class PatientStatusController : ControllerBase
    {
        private readonly IPatientStatusService _patientstatus;

        public PatientStatusController(IPatientStatusService patientstatus)
        {
            _patientstatus = patientstatus;
        }

        [HttpGet]
        [Route("patientstatus")]
        public IEnumerable<PatientStatus> GetIdentifiedSitesByCountry()
        {
            return _patientstatus.GetData();
        }
    }
}
