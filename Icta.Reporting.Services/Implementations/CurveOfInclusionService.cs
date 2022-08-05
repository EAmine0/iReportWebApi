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

    public class CurveOfInclusionService : ICurveOfInclusionService
    {
        private readonly IIctaCubeRepository<CurveOfInclusion> _ictaCubeRepository;

        public CurveOfInclusionService(IIctaCubeRepository<CurveOfInclusion> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<CurveOfInclusion> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Nb Patient] } ON COLUMNS, " +
                "NON EMPTY { ([Curve].[Month].[Month].ALLMEMBERS * [Curve].[Label].[Label].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS " +
                "FROM ( SELECT ( { [Study].[Study name].&[047SIMULTI] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[047SIMULTI] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> month = new List<string>();
            List<int> included = new List<int>();
            List<int> randomised = new List<int>();
            List<int> theoretical = new List<int>();

            while (reader.Read())   // read
            {
                //included.Add(int.Parse(reader.GetValue(2).ToString()));
                if (reader.GetValue(2).ToString() == "Included")
                {
                    included.Add(int.Parse(reader.GetValue(4).ToString()));
                }
                if (reader.GetValue(2).ToString() == "Randomised")
                {
                    randomised.Add(int.Parse(reader.GetValue(4).ToString()));
                }
                if (reader.GetValue(2).ToString() == "Theoretical")
                {
                    theoretical.Add(int.Parse(reader.GetValue(4).ToString()));
                    month.Add(reader.GetValue(0).ToString());
                }
                //Console.WriteLine(reader.GetValue(3).ToString());
            }

            return Enumerable.Range(0, month.Count).Select(index => new CurveOfInclusion()
            {
                date = month[index],
                included = included[index],
                randomised = randomised[index],
                theoretical = theoretical[index]
            }).ToArray();
            
        }
    }
}
