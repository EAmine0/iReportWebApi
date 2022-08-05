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
    public class DocumentConformityService : IDocumentConformityService
    {
        private readonly IIctaCubeRepository<DocumentConformity> _ictaCubeRepository;

        public DocumentConformityService(IIctaCubeRepository<DocumentConformity> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DocumentConformity> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[Document receipt], [Measures].[Document default unresolved] } ON COLUMNS, " +
                "NON EMPTY { ([Document].[Document - conform].[Document - conform].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS " +
                "FROM ( SELECT ( { [Study].[Study name].&[047SIMULTI] } ) ON COLUMNS FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[047SIMULTI] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> value = new List<int>();
            int received = 0;
            int default_unresolved = 0;

            while (reader.Read())   // read
            {
                //included.Add(int.Parse(reader.GetValue(2).ToString()));
                if (reader.GetValue(0).ToString() == "No")
                {
                    label.Add(reader.GetValue(0).ToString());
                    value.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                if (reader.GetValue(0).ToString() == "Yes")
                {
                    label.Add(reader.GetValue(0).ToString());
                    value.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                received = received + int.Parse(reader.GetValue(2).ToString());
                if (reader.IsDBNull(3))
                {
                    default_unresolved = default_unresolved + 0;
                }
                else
                {
                    default_unresolved = default_unresolved + int.Parse(reader.GetValue(3).ToString());
                }
                //Console.WriteLine(reader.GetValue(5).ToString());
            }

            return Enumerable.Range(0, 2).Select(index => new DocumentConformity()
            {
                NoYes = label[index],
                Value = value[index],
                Received = received,
                DefaultUnresolved = default_unresolved
            }).ToArray();

        }
    }
}
