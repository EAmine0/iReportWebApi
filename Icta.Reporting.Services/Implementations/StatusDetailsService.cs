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
    public class StatusDetailsService : IStatusDetailsService
    {
        private readonly IIctaCubeRepository<StatusDetails> _ictaCubeRepository;

        public StatusDetailsService(IIctaCubeRepository<StatusDetails> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<StatusDetails> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Site last status total] } ON COLUMNS, NON EMPTY { ([Site].[Site - code and name].[Site - code and name].ALLMEMBERS * " +
                "[Site status].[Site - status].[Site - status].ALLMEMBERS * [Site status].[Site - status reason].[Site - status reason].ALLMEMBERS * [Status].[Filter].[Date].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Monitoring date].[Monitoring - status date].[All] } ) ON COLUMNS " +
                "FROM ( SELECT ( { [Site status].[Site - last status YN].&[Yes] } ) ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA]))) " +
                "WHERE ( [Study].[Study name].&[TANGO], [Site status].[Site - last status YN].&[Yes], [Monitoring date].[Monitoring - status date].[All] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> site = new List<string>();
            List<string> last_status = new List<string>();
            List<string> status_reason = new List<string>();
            List<string> status_date = new List<string>();

            while (reader.Read())   // read 0 2 4 10
            {
                site.Add(reader.GetValue(0).ToString());
                last_status.Add(reader.GetValue(2).ToString());
                status_reason.Add(reader.GetValue(4).ToString());
                status_date.Add(reader.GetValue(10).ToString());
            }

            return Enumerable.Range(0, site.Count).Select(index => new StatusDetails()
            {
                Site = site[index],
                LastStatus = last_status[index],
                StatusReason = status_reason[index],
                StatusDate = status_date[index]

            }).ToArray();

        }
    }
}
