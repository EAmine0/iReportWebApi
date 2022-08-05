using Icta.Reporting.Data.Models;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Icta.Reporting.Services.Implementations
{
    public class IdentifiedSiteByCountryService : IIdentifiedSiteByCountryService
    {
        private readonly IIctaCubeRepository<IdentifiedSiteByCountry> _ictaCubeRepository;

        public IdentifiedSiteByCountryService(IIctaCubeRepository<IdentifiedSiteByCountry> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<IdentifiedSiteByCountry> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[Site status total] } ON COLUMNS, " +
                "NON EMPTY { ([Division domain].[Division domain - country].[Division domain - country].ALLMEMBERS * [Site status].[Site - status].[Site - status].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[FIRE] } ) ON COLUMNS " +
                "FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[FIRE] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> value = new List<int>();

            while (reader.Read())   // read
            {
                if (reader.GetValue(2).ToString() == "Identified")
                {
                    label.Add(reader.GetValue(0).ToString());
                    value.Add(int.Parse(reader.GetValue(4).ToString()));
                }
            }

            return Enumerable.Range(0, label.Count).Select(index => new IdentifiedSiteByCountry()
            {
                Country = label[index],
                SiteIdentified = value[index]
            }).ToArray();
        }
    }
}
