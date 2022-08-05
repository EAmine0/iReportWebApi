using Icta.Reporting.Data.Models;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Icta.Reporting.Services.Implementations
{
    public class SitesService : ISitesService
    {
        private readonly IIctaCubeRepository<Sites> _ictaCubeRepository;

        public SitesService(IIctaCubeRepository<Sites> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<Sites> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Nb Potential Site], [Measures].[Site status total] } ON COLUMNS " +
                "FROM ( SELECT ( { [Site status].[Site - status].&[Initiated] } ) ON COLUMNS " +
                "FROM ( SELECT ( { [Study].[Study name].&[EPIPARK] } ) ON COLUMNS FROM [Cube ICTA])) " +
                "WHERE ( [Study].[Study name].&[EPIPARK], [Site status].[Site - status].&[Initiated] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<int> TotalValue = new List<int>();
            List<int> PotentialValue = new List<int>();

            while (reader.Read())
            {
                TotalValue.Add(int.Parse(reader.GetValue(0).ToString()));
                PotentialValue.Add(int.Parse(reader.GetValue(1).ToString()));
            }

            return Enumerable.Range(0, TotalValue.Count).Select(index => new Sites()
            {
                TotalValue = TotalValue[index],
                PotentialValue = PotentialValue[index]

            }).ToArray();
        }

    }
}
