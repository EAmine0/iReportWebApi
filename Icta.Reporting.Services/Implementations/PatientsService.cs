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
    public class PatientsService : IPatientsService
    {
        private readonly IIctaCubeRepository<Patients> _ictaCubeRepository;

        public PatientsService(IIctaCubeRepository<Patients> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }


        public IEnumerable<Patients> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[Nb Potential Patient], [Measures].[Patient status total] } ON COLUMNS " +
                "FROM ( SELECT ( { [Patient status].[Patient - status].[Included] } ) ON COLUMNS " +
                "FROM ( SELECT ( { [Study].[Study name].&[EPIPARK] } ) ON COLUMNS " +
                "FROM [Cube ICTA])) " +
                "WHERE ( [Study].[Study name].&[EPIPARK], [Patient status].[Patient - status].[Included] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<int> TotalValue = new List<int>();
            List<int> PotentialValue = new List<int>();

            while (reader.Read())
            {
                TotalValue.Add(int.Parse(reader.GetValue(0).ToString()));
                PotentialValue.Add(int.Parse(reader.GetValue(1).ToString()));
            }

            return Enumerable.Range(0, TotalValue.Count).Select(index => new Patients()
            {
                TotalValue = TotalValue[index],
                PotentialValue = PotentialValue[index]

            }).ToArray();
        }
    }
}
