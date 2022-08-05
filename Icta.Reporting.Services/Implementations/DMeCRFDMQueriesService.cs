using Icta.Reporting.Data.Models;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Services.Implementations
{
    public class DMeCRFDMQueriesService : IDMeCRFDMQueriesService
    {
        private readonly IIctaCubeRepository<DMeCRFDMQueries> _ictaCubeRepository;

        public DMeCRFDMQueriesService(IIctaCubeRepository<DMeCRFDMQueries> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMeCRFDMQueries> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Consultation expected], [Measures].[Consultation in progress], [Measures].[Consultation data entry], " +
                "[Measures].[Consultation signed] } ON COLUMNS, NON EMPTY { ([ECRF consultation].[ECRF consultation - consultation].[ECRF consultation - consultation].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[TANGO] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            //Api à finir

            var reader = _ictaCubeRepository.GetDatas(query);

      

            while (reader.Read())  
            {
            }

            return Enumerable.Range(0, 10).Select(index => new DMeCRFDMQueries()
            {
                Label = "jkl",
                Issued = 10,
                Closed = 10,
                Sent = 10,
                Received = 10,
                Completed = 10,
                Confirmed = 10,
                Resolved = 10

            }).ToArray();

        }
    }
}
