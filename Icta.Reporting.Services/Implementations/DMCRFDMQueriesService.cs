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
    public class DMCRFDMQueriesService : IDMCRFDMQueriesService
    {
        private readonly IIctaCubeRepository<DMCRFDMQueries> _ictaCubeRepository;

        public DMCRFDMQueriesService(IIctaCubeRepository<DMCRFDMQueries> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<DMCRFDMQueries> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Queries total] } ON COLUMNS, " +
                "NON EMPTY { ([Data query status].[Data queries - status].[Data queries - status].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS " +
                "FROM ( SELECT ( { [Data query status].[Data queries - status].&[Sent], [Data query status].[Data queries - status].&[Received], " +
                "[Data query status].[Data queries - status].&[Issued], [Data query status].[Data queries - status].&[Completed], " +
                "[Data query status].[Data queries - status].&[Confirmed], [Data query status].[Data queries - status].&[Resolved], " +
                "[Data query status].[Data queries - status].&[Closed] } ) ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS " +
                "FROM [Cube ICTA])) WHERE ( [Study].[Study name].&[TANGO] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> issued = new List<int>();
            List<int> closed = new List<int>();
            List<int> sent = new List<int>();
            List<int> received = new List<int>();
            List<int> completed = new List<int>();
            List<int> confirmed = new List<int>();
            List<int> resolved = new List<int>();

            while (reader.Read())   // read
            {
                label.Add(reader.GetValue(0).ToString());
                if (reader.GetValue(0).ToString() == "Issued")
                {
                    issued.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    issued.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Closed")
                {
                    closed.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    closed.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Sent")
                {
                    sent.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    sent.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Received")
                {
                    received.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    received.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Completed")
                {
                    completed.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    completed.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Confirmed")
                {
                    confirmed.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    confirmed.Add(0);
                }
                if (reader.GetValue(0).ToString() == "Resolved")
                {
                    resolved.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                else
                {
                    resolved.Add(0);
                }

            }

            return Enumerable.Range(0, 5).Select(index => new DMCRFDMQueries()
            {
                label = label[index],
                issued = issued[index],
                closed = sent[index],
                sent = received[index],
                received = completed[index],
                completed = confirmed[index],
                confirmed = resolved[index],
                resolved = closed[index]

            }).ToArray();

        }
    }
}
