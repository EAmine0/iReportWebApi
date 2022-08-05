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
    public class MonitoringService : IMonitoringService
    {
        private readonly IIctaCubeRepository<Monitoring> _ictaCubeRepository;

        public MonitoringService(IIctaCubeRepository<Monitoring> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }


        public IEnumerable<Monitoring> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Monitoring status total], [Measures].[AVG monitoring per site] } ON COLUMNS, " +
                "NON EMPTY { ([Monitoring].[Monitoring - nature].[Monitoring - nature].ALLMEMBERS * [Monitoring].[Monitoring - mode].[Monitoring - mode].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Monitoring status].[Monitoring - last status YN].&[Yes] } ) ON COLUMNS " +
                "FROM ( SELECT ( { [Monitoring].[Monitoring - mode].&[Phone], [Monitoring].[Monitoring - mode].&[Visit] } ) ON COLUMNS " +
                "FROM ( SELECT ( { [Monitoring].[Monitoring - nature].&[Initiation], [Monitoring].[Monitoring - nature].&[Monitoring], " +
                "[Monitoring].[Monitoring - nature].&[Close-out active site], [Monitoring].[Monitoring - nature].&[Close-out inactive site], " +
                "[Monitoring].[Monitoring - nature].&[Data collection] } ) ON COLUMNS FROM ( SELECT ( { [Monitoring].[Monitoring - last status].&[Performed], " +
                "[Monitoring].[Monitoring - last status].&[Successful] } ) ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[FIRE] } ) ON COLUMNS FROM [Cube ICTA]))))) " +
                "WHERE ( [Study].[Study name].&[FIRE], [Monitoring].[Monitoring - last status].CurrentMember, [Monitoring status].[Monitoring - last status YN].&[Yes] ) CELL " +
                "PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> nature = new List<string>();
            List<string> mode = new List<string>();
            List<int> last_status = new List<int>();
            List<float> avg_monitoring_per_site = new List<float>();

            while (reader.Read()) 
            {
                nature.Add(reader.GetValue(0).ToString());
                mode.Add(reader.GetValue(2).ToString());
                last_status.Add(int.Parse(reader.GetValue(4).ToString()));
                avg_monitoring_per_site.Add((float)Math.Round(float.Parse(reader.GetValue(5).ToString()), 2));

            }

            return Enumerable.Range(0, nature.Count).Select(index => new Monitoring()
            {
                Nature = nature[index],
                Mode = mode[index],
                LastStatus = last_status[index],
                AvgMonitoringPerSite = avg_monitoring_per_site[index],


            }).ToArray();
        }
    }
}
