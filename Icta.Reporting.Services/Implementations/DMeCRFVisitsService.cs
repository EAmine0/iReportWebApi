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
    public class DMeCRFVisitsService : IDMeCRFVisitsService
    {
        private readonly IIctaCubeRepository<DMeCRFVisits> _ictaCubeRepository;

        public DMeCRFVisitsService(IIctaCubeRepository<DMeCRFVisits> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMeCRFVisits> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[% eCRF data entry], [Measures].[% eCRF signed] } ON COLUMNS " +
                "FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[TANGO] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<float> entry = new List<float>();
            List<float> signed = new List<float>();

            while (reader.Read())
            {
                entry.Add(float.Parse(reader.GetValue(0).ToString()));
                signed.Add(float.Parse(reader.GetValue(1).ToString()));
            }

            return Enumerable.Range(0, entry.Count).Select(index => new DMeCRFVisits()
            {
                DataEntry = entry[index],
                Signed = signed[index]
            }).ToArray();

        }
    }
}
