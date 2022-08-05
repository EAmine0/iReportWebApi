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
    public class DMCRFPatientMandatoryConsultController : ControllerBase
    {
        private readonly IDMCRFPatientMandatoryConsultService _dmcrfPatientMandatoryConsult;

        public DMCRFPatientMandatoryConsultController(IDMCRFPatientMandatoryConsultService dmcrfPatientMandatoryConsult)
        {
            _dmcrfPatientMandatoryConsult = dmcrfPatientMandatoryConsult;
        }

        [HttpGet]
        [Route("DMCRFPatientMandatoryConsult")]
        public IEnumerable<DMCRFPatientMandatoryConsult> GetAPI()
        {
            return _dmcrfPatientMandatoryConsult.GetData();
        }
    }
}
