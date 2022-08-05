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
    public class TimelineService : ITimelineService
    {
        private readonly IIctaCubeRepository<Timeline> _ictaCubeRepository;

        public TimelineService(IIctaCubeRepository<Timeline> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<Timeline> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Milestone total] } ON COLUMNS, " +
                "NON EMPTY { ([Milestone].[Milestone - phase].[Milestone - phase].ALLMEMBERS * [Milestone].[Milestone - milestone].[Milestone - milestone].ALLMEMBERS * " +
                "[Milestone - actual].[Date].[Date].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Milestone].[Milestone - level].&[Study] } ) " +
                "ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS FROM [Cube ICTA])) WHERE ( [Study].[Study name].&[TANGO], [Milestone].[Milestone - level].&[Study] ) " +
                "CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> phase = new List<string>();
            List<string> milestone = new List<string>();
            List<string> pre_date = new List<string>();
            List<string> date = new List<string>();
            List<string> post_date = new List<string>();

            //DateTime b = test.AddDays(7);

            while (reader.Read())   // read 0 2 4 10
            {

                if (reader.GetValue(4).ToString() == "Unknown")
                {
                    Console.WriteLine("Unknown found");
                }
                else
                {
                    phase.Add(reader.GetValue(0).ToString());
                    milestone.Add(reader.GetValue(2).ToString());
                    pre_date.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddMonths(-3).ToString("yyyy-MM-dd"));
                    date.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("dddd, dd MMMM yyyy"));
                    post_date.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddMonths(3).ToString("yyyy-MM-dd"));
                }
            }


            return Enumerable.Range(0, date.Count).Select(index => new Timeline()
            {
                phase = phase[index],
                milestone = milestone[index],
                pre_date = pre_date[index],
                date = date[index],
                post_date = post_date[index],

            }).ToArray();

        }
    }
}
