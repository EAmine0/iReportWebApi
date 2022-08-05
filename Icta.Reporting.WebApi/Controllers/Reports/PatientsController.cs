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
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patients;

        public PatientsController(IPatientsService patients)
        {
            _patients = patients;
        }

        [HttpGet]
        [Route("patients")]
        public IEnumerable<Patients> GetPatients()
        {
            return _patients.GetData();
        }
    }
}
