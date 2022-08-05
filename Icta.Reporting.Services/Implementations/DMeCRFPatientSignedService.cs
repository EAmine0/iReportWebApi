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
    public class DMeCRFPatientSignedService : IDMeCRFPatientSignedService
    {
        private readonly IIctaCubeRepository<DMeCRFPatientSigned> _ictaCubeRepository;

        public DMeCRFPatientSignedService(IIctaCubeRepository<DMeCRFPatientSigned> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMeCRFPatientSigned> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Patient signed] } ON COLUMNS " +
                "FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[TANGO] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<int> signed = new List<int>();
            while (reader.Read())   // read
            {
                signed.Add(int.Parse(reader.GetValue(0).ToString()));
            }

            return Enumerable.Range(0, signed.Count).Select(index => new DMeCRFPatientSigned()
            {
                Signed = signed[index],
            }).ToArray();

        }
    }
}
