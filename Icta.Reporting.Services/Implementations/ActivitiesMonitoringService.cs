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
    public class ActivitiesMonitoringService : IActivitiesMonitoringService
    {
        private readonly IDataWarehouseRepository<ActivitiesMonitoring> _ictaDWHRepository;

        public ActivitiesMonitoringService(IDataWarehouseRepository<ActivitiesMonitoring> ictaDWHRepository)
        {
            _ictaDWHRepository = ictaDWHRepository;
        }

        public IEnumerable<ActivitiesMonitoring> GetData()
        {
            string query = @"SELECT TOP (1000) [sstNameListSecto],[sstrCentreCodeName],[sstrSiteStatus],[sstrFAList]
                              ,[dtSelected]
                              ,[dtReady]
                              ,[dtFirstMonit]
                              ,[dtLastMonit]
                              ,[dtFirstMonitClosed]
                              ,[countMonit]
                          FROM[ICTA_DWH].[dbo].[vw_site_activity] where NomEtude = 'TANGO' order by sstrCentreCodeName";

            var reader = _ictaDWHRepository.GetDatas(query);

            List<string> division_domain = new List<string>();
            List<string> site = new List<string>();
            List<string> site_status = new List<string>();
            List<string> financial_agreement = new List<string>();
            List<string> selected_date = new List<string>();
            List<string> readyToInclude_date = new List<string>();
            List<string> firstMonitoring_date = new List<string>();
            List<string> lastMonitoring_date = new List<string>();
            List<string> closeOut_date = new List<string>();
            List<int> nb_monitoring = new List<int>();


            while (reader.Read())   // read 0 2 4 10
            {
                division_domain.Add(reader.GetValue(0).ToString());
                site.Add(reader.GetValue(1).ToString());
                site_status.Add(reader.GetValue(2).ToString());
                financial_agreement.Add(reader.GetValue(3).ToString());
                selected_date.Add(reader.GetValue(4).ToString());
                readyToInclude_date.Add(reader.GetValue(5).ToString());
                firstMonitoring_date.Add(reader.GetValue(6).ToString());
                lastMonitoring_date.Add(reader.GetValue(7).ToString());
                closeOut_date.Add(reader.GetValue(8).ToString());
                nb_monitoring.Add(int.Parse(reader.GetValue(9).ToString()));

                Console.WriteLine("la colonne 0 : " + reader.GetValue(0).ToString());

            }


            return Enumerable.Range(0, division_domain.Count).Select(index => new ActivitiesMonitoring()
            {
                division_domain = division_domain[index],
                site = site[index],
                site_status = site_status[index],
                financial_agreement = financial_agreement[index],
                selected_date = selected_date[index],
                readyToInclude_date = readyToInclude_date[index],
                firstMonitoring_date = firstMonitoring_date[index],
                lastMonitoring_date = lastMonitoring_date[index],
                closeOut_date = closeOut_date[index],
                nb_monitoring = nb_monitoring[index],


            }).ToArray();

        }
    }
}
