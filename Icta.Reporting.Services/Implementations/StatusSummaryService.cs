﻿using Icta.Reporting.Data.Models;
using Icta.Reporting.Repository.Interfaces;
using Icta.Reporting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icta.Reporting.Services.Implementations
{
    public class StatusSummaryService : IStatusSummaryService
    {
        private readonly IIctaCubeRepository<StatusSummary> _ictaCubeRepository;

        public StatusSummaryService(IIctaCubeRepository<StatusSummary> ictaCubeRepository)
        {
            _ictaCubeRepository = ictaCubeRepository;
        }

        public IEnumerable<StatusSummary> GetData()
        {
            string query = " SELECT NON EMPTY { [Measures].[Site status total], " +
                "[Measures].[Site last status total] } ON COLUMNS, NON EMPTY { ([Site status].[Site - status].[Site - status].ALLMEMBERS ) } " +
                "DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM ( SELECT ( { [Study].[Study name].&[VERONE] } ) " +
                "ON COLUMNS FROM [Cube ICTA]) WHERE ( [Study].[Study name].&[VERONE] ) " +
                "CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            var reader = _ictaCubeRepository.GetDatas(query);

            List<string> label = new List<string>();
            List<int> statusTotal = new List<int>();
            List<int> lastStatusTotal = new List<int>();

            while (reader.Read())
            {
                label.Add(reader.GetValue(0).ToString());
                statusTotal.Add(int.Parse(reader.GetValue(2).ToString()));
                lastStatusTotal.Add(int.Parse(reader.GetValue(3).ToString()));
            }

            return Enumerable.Range(0, label.Count).Select(index => new StatusSummary()
            {
                Status = label[index],
                StatusTotal = statusTotal[index],
                LastStatusTotal = lastStatusTotal[index],

            }).ToArray();

        }
    }
}
