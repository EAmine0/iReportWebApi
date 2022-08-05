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
    public class DMCRFPatientMandatoryConsultService : IDMCRFPatientMandatoryConsultService
    {
        private readonly IIctaCubeRepository<DMCRFPatientMandatoryConsult> _ictaCubeRepository;

        public DMCRFPatientMandatoryConsultService(IIctaCubeRepository<DMCRFPatientMandatoryConsult> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMCRFPatientMandatoryConsult> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[Consultation NA], [Measures].[Consultation incomplete], [Measures].[Consultation complete], " +
                "[Measures].[Consultation DEA], [Measures].[Consultation DEB], [Measures].[Consultation clean] } ON COLUMNS, " +
                "NON EMPTY { ([CRF consultation].[CRF consultation].[CRF consultation].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS " +
                "FROM ( SELECT ( { [Study].[Study name].&[ATU_MUCOVISCIDOSE] } ) ON COLUMNS FROM ( SELECT ( { [CRF section].[CRF section - requirement type].&[Mandatory (all patients)] } ) ON COLUMNS " +
                "FROM [Cube ICTA])) WHERE ( [CRF section].[CRF section - requirement type].&[Mandatory (all patients)], [Study].[Study name].&[ATU_MUCOVISCIDOSE] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> na = new List<int>();
            List<int> incomplete = new List<int>();
            List<int> complete = new List<int>();
            List<int> dea = new List<int>();
            List<int> deb = new List<int>();
            List<int> clean = new List<int>();

            while (reader.Read())   
            {
                label.Add(reader.GetValue(0).ToString());
                na.Add(int.Parse(reader.GetValue(2).ToString()));
                incomplete.Add(int.Parse(reader.GetValue(3).ToString()));
                complete.Add(int.Parse(reader.GetValue(4).ToString()));
                dea.Add(int.Parse(reader.GetValue(5).ToString()));
                deb.Add(int.Parse(reader.GetValue(6).ToString()));
                clean.Add(int.Parse(reader.GetValue(7).ToString()));
            }

            return Enumerable.Range(0, 5).Select(index => new DMCRFPatientMandatoryConsult()
            {
                Label = label[index],
                NA = na[index],
                Incomplete = incomplete[index],
                Complete = complete[index],
                DEA = dea[index],
                DEB = deb[index],
                Clean = clean[index]

            }).ToArray();

        }
    }
}
