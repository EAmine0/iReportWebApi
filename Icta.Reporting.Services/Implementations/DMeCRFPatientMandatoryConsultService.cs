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
    public class DMeCRFPatientMandatoryConsultService : IDMeCRFPatientMandatoryConsultService
    {
        private readonly IIctaCubeRepository<DMeCRFPatientMandatoryConsult> _ictaCubeRepository;

        public DMeCRFPatientMandatoryConsultService(IIctaCubeRepository<DMeCRFPatientMandatoryConsult> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMeCRFPatientMandatoryConsult> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Consultation expected], [Measures].[Consultation in progress], [Measures].[Consultation data entry], " +
                "[Measures].[Consultation signed] } ON COLUMNS, NON EMPTY { ([ECRF consultation].[ECRF consultation - consultation].[ECRF consultation - consultation].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[TANGO] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> expected = new List<int>();
            List<int> progress = new List<int>();
            List<int> data_entry = new List<int>();
            List<int> signed = new List<int>();

            List<int> deb = new List<int>();
            List<int> clean = new List<int>();

            while (reader.Read())
            {
                label.Add(reader.GetValue(0).ToString());
                expected.Add(int.Parse(reader.GetValue(2).ToString()));
                progress.Add(int.Parse(reader.GetValue(3).ToString()));
                data_entry.Add(int.Parse(reader.GetValue(4).ToString()));
                signed.Add(int.Parse(reader.GetValue(5).ToString()));
            }

            return Enumerable.Range(0, 15).Select(index => new DMeCRFPatientMandatoryConsult()
            {
                Label = label[index],
                Expected = expected[index],
                InProgress = progress[index],
                DataEntry = data_entry[index],
                Signed = signed[index],


            }).ToArray();

        }
    }
}
