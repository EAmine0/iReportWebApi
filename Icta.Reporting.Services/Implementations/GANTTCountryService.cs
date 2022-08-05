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
    public class GANTTCountryService : IGANTTCountryService
    {
        private readonly IIctaCubeRepository<GANTTCountry> _ictaCubeRepository;

        public GANTTCountryService(IIctaCubeRepository<GANTTCountry> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<GANTTCountry> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Duration Planned], [Measures].[Duration Actual] } ON COLUMNS, " +
                "NON EMPTY { ([Address].[Country].[Country].ALLMEMBERS * [Milestone GANTT].[Gantt - milestone phase].[Gantt - milestone phase].ALLMEMBERS * " +
                "[Milestone GANTT].[Gantt - start date planned].[Gantt - start date planned].ALLMEMBERS * [Milestone GANTT].[Gantt - start date actual].[Gantt - start date actual].ALLMEMBERS ) } DIMENSION " +
                "PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Milestone GANTT].[Gantt - milestone level].&[Country] } ) ON COLUMNS FROM ( SELECT ( { [Study].[Study name].&[TANGO] } ) ON COLUMNS " +
                "FROM [Cube ICTA])) WHERE ( [Study].[Study name].&[TANGO], [Milestone GANTT].[Gantt - milestone level].&[Country] ) CELL PROPERTIES " +
                "VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> country = new List<string>();

            List<string> regulatory_start_date_planned = new List<string>();
            List<string> regulatory_end_date_planned = new List<string>();
            List<string> regulatory_start_date_actual = new List<string>();
            List<string> regulatory_end_date_actual = new List<string>();

            List<string> startup_start_date_planned = new List<string>();
            List<string> startup_end_date_planned = new List<string>();
            List<string> startup_start_date_actual = new List<string>();
            List<string> startup_end_date_actual = new List<string>();

            List<string> coredocs_start_date_planned = new List<string>();
            List<string> coredocs_end_date_planned = new List<string>();
            List<string> coredocs_start_date_actual = new List<string>();
            List<string> coredocs_end_date_actual = new List<string>();

            List<string> siteselection_start_date_planned = new List<string>();
            List<string> siteselection_end_date_planned = new List<string>();
            List<string> siteselection_start_date_actual = new List<string>();
            List<string> siteselection_end_date_actual = new List<string>();

            List<string> initiation_start_date_planned = new List<string>();
            List<string> initiation_end_date_planned = new List<string>();
            List<string> initiation_start_date_actual = new List<string>();
            List<string> initiation_end_date_actual = new List<string>();

            List<string> recruitment_start_date_planned = new List<string>();
            List<string> recruitment_end_date_planned = new List<string>();
            List<string> recruitment_start_date_actual = new List<string>();
            List<string> recruitment_end_date_actual = new List<string>();

            List<string> monitoring_start_date_planned = new List<string>();
            List<string> monitoring_end_date_planned = new List<string>();
            List<string> monitoring_start_date_actual = new List<string>();
            List<string> monitoring_end_date_actual = new List<string>();



            //DateTime test = DateTime.Parse("2015-04-18");
            //Console.WriteLine("ancoer before : " + test);

            //Console.WriteLine("before : " + test.ToString("yyyy-MM-dd"));

            //DateTime b = test.AddDays(7);

            //Console.WriteLine("after : " + b.ToString("yyyy-MM-dd"));

            // country => 0
            // type => 2
            // start_date_planned => 4
            // start_date_actual => 6
            // duration planned => 8
            // duration actual => 9
            int i = 0;

            while (reader.Read())   // read 0 2 4 10
            {


                if (reader.GetValue(2).ToString() == "Start-up")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        country.Add(reader.GetValue(0).ToString());
                        startup_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        startup_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        startup_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        startup_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        startup_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        startup_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        startup_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        startup_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Core docs")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        coredocs_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        coredocs_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        coredocs_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        coredocs_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        coredocs_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        coredocs_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        coredocs_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        coredocs_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Sites selection")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        siteselection_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        siteselection_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        siteselection_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        siteselection_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        siteselection_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        siteselection_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        siteselection_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        siteselection_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Regulatory")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        regulatory_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        regulatory_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        regulatory_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        regulatory_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        regulatory_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        regulatory_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        regulatory_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        regulatory_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Initiation")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        initiation_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        initiation_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        initiation_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        initiation_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        initiation_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        initiation_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        initiation_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        initiation_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Recruitment")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        recruitment_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        recruitment_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        recruitment_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        recruitment_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        recruitment_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        recruitment_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        recruitment_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        recruitment_end_date_actual.Add(" ");
                    }
                }
                if (reader.GetValue(2).ToString() == "Monitoring")
                {
                    if (reader.GetValue(4).ToString() != "")
                    {
                        monitoring_start_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        monitoring_start_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        monitoring_start_date_actual.Add(DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        monitoring_start_date_actual.Add(" ");
                    }
                    if (reader.GetValue(4).ToString() != "")
                    {
                        monitoring_end_date_planned.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(8).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        monitoring_end_date_planned.Add(" ");
                    }
                    if (reader.GetValue(6).ToString() != "")
                    {
                        monitoring_end_date_actual.Add(DateTime.Parse(reader.GetValue(4).ToString()).AddDays(int.Parse(reader.GetValue(9).ToString())).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        monitoring_end_date_actual.Add(" ");
                    }
                }

            }


            return Enumerable.Range(0, country.Count).Select(index => new GANTTCountry()
            {
                country = country[index],
                regulatory_start_date_planned = regulatory_start_date_planned[index],
                regulatory_end_date_planned = regulatory_end_date_planned[index],
                regulatory_start_date_actual = regulatory_start_date_actual[index],
                regulatory_end_date_actual = regulatory_end_date_actual[index],

                startup_start_date_planned = startup_start_date_planned[index],
                startup_end_date_planned = startup_end_date_planned[index],
                startup_start_date_actual = startup_start_date_actual[index],
                startup_end_date_actual = startup_end_date_actual[index],


                coredocs_start_date_planned = coredocs_start_date_planned[index],
                coredocs_end_date_planned = coredocs_end_date_planned[index],
                coredocs_start_date_actual = coredocs_start_date_actual[index],
                coredocs_end_date_actual = coredocs_end_date_actual[index],


                siteselection_start_date_planned = siteselection_start_date_planned[index],
                siteselection_end_date_planned = siteselection_end_date_planned[index],
                siteselection_start_date_actual = siteselection_start_date_actual[index],
                siteselection_end_date_actual = siteselection_end_date_actual[index],

                initiation_start_date_planned = initiation_start_date_planned[index],
                initiation_end_date_planned = initiation_end_date_planned[index],
                initiation_start_date_actual = initiation_start_date_actual[index],
                initiation_end_date_actual = initiation_end_date_actual[index],

                recruitment_start_date_planned = recruitment_start_date_planned[index],
                recruitment_end_date_planned = recruitment_end_date_planned[index],
                recruitment_start_date_actual = recruitment_start_date_actual[index],
                recruitment_end_date_actual = recruitment_end_date_actual[index],


                monitoring_start_date_planned = monitoring_start_date_planned[index],
                monitoring_end_date_planned = monitoring_end_date_planned[index],
                monitoring_start_date_actual = monitoring_start_date_actual[index],
                monitoring_end_date_actual = monitoring_end_date_actual[index]


            }).ToArray();

        }
    }
}
