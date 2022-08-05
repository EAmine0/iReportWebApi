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
    public class DMeCRFPatientMandatoryConsultController : ControllerBase
    {
        private readonly IDMeCRFPatientMandatoryConsultService _dmecrfPatientMandatoryConsult;

        public DMeCRFPatientMandatoryConsultController(IDMeCRFPatientMandatoryConsultService dmecrfPatientMandatoryConsult)
        {
            _dmecrfPatientMandatoryConsult = dmecrfPatientMandatoryConsult;
        }

        [HttpGet]
        [Route("DMeCRFPatientMandatoryConsult")]
        public IEnumerable<DMeCRFPatientMandatoryConsult> GetAPI()
        {
            return _dmecrfPatientMandatoryConsult.GetData();
        }
    }
}
