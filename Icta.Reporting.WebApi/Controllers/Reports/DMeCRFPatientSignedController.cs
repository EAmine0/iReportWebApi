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
    public class DMeCRFPatientSignedController : ControllerBase
    {
        private readonly IDMeCRFPatientSignedService _dmecrfPatientSigned;

        public DMeCRFPatientSignedController(IDMeCRFPatientSignedService dmecrfPatientSigned)
        {
            _dmecrfPatientSigned = dmecrfPatientSigned;
        }

        [HttpGet]
        [Route("DMeCRFPatientSigned")]
        public IEnumerable<DMeCRFPatientSigned> GetAPI()
        {
            return _dmecrfPatientSigned.GetData();
        }
    }
}
