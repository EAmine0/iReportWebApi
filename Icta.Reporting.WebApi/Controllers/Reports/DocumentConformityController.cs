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
    public class DocumentConformityController : ControllerBase
    {
        private readonly IDocumentConformityService _documentConformity;

        public DocumentConformityController(IDocumentConformityService documentConformity)
        {
            _documentConformity = documentConformity;
        }

        [HttpGet]
        [Route("curveOfInclusion")]
        public IEnumerable<DocumentConformity> GetCurveOfInclusions()
        {
            return _documentConformity.GetData();
        }
    }
}
