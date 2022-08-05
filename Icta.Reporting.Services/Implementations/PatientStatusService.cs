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
    public class PatientStatusService : IPatientStatusService
    {
        private readonly IIctaCubeRepository<PatientStatus> _ictaCubeRepository;

        public PatientStatusService(IIctaCubeRepository<PatientStatus> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<PatientStatus> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[Patient status total], [Measures].[Patient last status total] } ON COLUMNS, " +
                "NON EMPTY { ([Patient status].[Patient - status].[Patient - status].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS " +
                "FROM ( SELECT ( { [Study].[Study name].&[VERONE] } ) ON COLUMNS FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[VERONE] ) CELL " +
                "PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> status = new List<string>();
            List<int> statusTotal = new List<int>();
            List<int> lastStatusTotal = new List<int>();

            while (reader.Read())
            {
                status.Add(reader.GetValue(0).ToString());
                statusTotal.Add(int.Parse(reader.GetValue(2).ToString()));
                lastStatusTotal.Add(int.Parse(reader.GetValue(3).ToString()));
            }

            return Enumerable.Range(0, status.Count).Select(index => new PatientStatus()
            {
                Label = status[index],
                StatusTotal = statusTotal[index],
                LastStatusTotal = lastStatusTotal[index],

            }).ToArray();

            
        }
    }
}
