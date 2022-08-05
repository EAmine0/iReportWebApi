using Icta.Reporting.Data.Models;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Icta.Reporting.Services.Implementations
{
    public class SiteStatusService : ISiteStatusService
    {
        private readonly IIctaCubeRepository<SiteStatus> _ictaCubeRepository;

        public SiteStatusService(IIctaCubeRepository<SiteStatus> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<SiteStatus> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Site status total], " +
                "[Measures].[Site last status total] } ON COLUMNS, NON EMPTY { ([Site status].[Site - status].[Site - status].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[VERONE] } ) " +
                "ON COLUMNS FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[VERONE] ) " +
                "CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> statusTotal = new List<int>();
            List<int> lastStatusTotal = new List<int>();

            while (reader.Read())
            {
                label.Add(reader.GetValue(0).ToString());
                statusTotal.Add(int.Parse(reader.GetValue(2).ToString()));
                lastStatusTotal.Add(int.Parse(reader.GetValue(3).ToString()));
            }

            return Enumerable.Range(0, label.Count).Select(index => new SiteStatus()
            {
                Label = label[index],
                StatusTotal = statusTotal[index],
                LastStatusTotal = lastStatusTotal[index],

            }).ToArray();
        }
    }
}
