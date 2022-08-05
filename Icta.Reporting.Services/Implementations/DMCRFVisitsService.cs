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
    public class DMCRFVisitsService : IDMCRFVisitsService
    {
        private readonly IIctaCubeRepository<DMCRFVisits> _ictaCubeRepository;

        public DMCRFVisitsService(IIctaCubeRepository<DMCRFVisits> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMCRFVisits> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[% CRF entered], [Measures].[% CRF controlled] } ON COLUMNS " +
                "FROM ( SELECT ( { [Study].[Study name].&[ATU_HUMULIN] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[ATU_HUMULIN] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<float> entered = new List<float>();
            List<float> cleaned = new List<float>();

            while (reader.Read())   // read
            {
                entered.Add(float.Parse(reader.GetValue(0).ToString()));
                cleaned.Add(float.Parse(reader.GetValue(1).ToString()));
            }

            return Enumerable.Range(0, entered.Count).Select(index => new DMCRFVisits()
            {
                Entered = entered[index],
                Cleaned = cleaned[index]
            }).ToArray();

        }
    }
}
