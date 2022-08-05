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
    public class DMCRFPatientCleanedService : IDMCRFPatientCleanedService
    {
        private readonly IIctaCubeRepository<DMCRFPatientCleaned> _ictaCubeRepository;

        public DMCRFPatientCleanedService(IIctaCubeRepository<DMCRFPatientCleaned> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMCRFPatientCleaned> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Patient clean] } ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[ATU_NIRAPARIB] } ) ON COLUMNS " +
                "FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[ATU_NIRAPARIB] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<int> cleaned = new List<int>();

            while (reader.Read())   // read
            {
                cleaned.Add(int.Parse(reader.GetValue(0).ToString()));
            }

            return Enumerable.Range(0, cleaned.Count).Select(index => new DMCRFPatientCleaned()
            {
                Cleaned = cleaned[index],
            }).ToArray();

        }
    }
}
