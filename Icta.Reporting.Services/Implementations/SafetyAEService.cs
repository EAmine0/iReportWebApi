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
    public class SafetyAEService : ISafetyAEService
    {
        private readonly IIctaCubeRepository<SafetyAE> _ictaCubeRepository;

        public SafetyAEService(IIctaCubeRepository<SafetyAE> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<SafetyAE> GetData()
        {
            string query = "  SELECT NON EMPTY { [Measures].[AE total], [Measures].[AE ack not received] } ON COLUMNS, " +
                "NON EMPTY { ([AE].[AE - type].[AE - type].ALLMEMBERS * [AE].[AE - seriousness type].[AE - seriousness type].ALLMEMBERS ) } DIMENSION " +
                "PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[FIRE] } ) ON COLUMNS FROM [Cube ICTA]) " +
                "WHERE ( [Study].[Study name].&[FIRE] ) CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            string[] labels = { "Initial", "Follow-up" };
            List<int> value = new List<int>();

            int initial = 0;
            int followup = 0;
            int serious = 0;
            int ack_not_received = 0;

            while (reader.Read())   // read
            {
                //included.Add(int.Parse(reader.GetValue(2).ToString()));
                if (reader.GetValue(0).ToString() == "Initial")
                {
                    initial = initial + int.Parse(reader.GetValue(4).ToString());
                    //label.Add(reader.GetValue(0).ToString());
                    //value.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                if (reader.GetValue(0).ToString() == "Follow-up")
                {
                    followup = followup + int.Parse(reader.GetValue(4).ToString());
                    //label.Add(reader.GetValue(0).ToString());
                    //value.Add(int.Parse(reader.GetValue(2).ToString()));
                }
                if (reader.GetValue(2).ToString() != "Non-serious")
                {
                    serious = serious + int.Parse(reader.GetValue(5).ToString());
                }
                Console.WriteLine(reader.GetValue(5).ToString()); //0 2 4 5
                ack_not_received = ack_not_received + int.Parse(reader.GetValue(5).ToString());
            }

            value.Add(initial);
            value.Add(followup);

            return Enumerable.Range(0, 2).Select(index => new SafetyAE()
            {
                InitialFollowUP = labels[index],
                Value = value[index],
                Value2 = serious,
                AckNotReceived = ack_not_received
            }).ToArray();

        }
    }
}
