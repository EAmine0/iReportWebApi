using Icta.Reporting.Data.Interfaces;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

namespace Icta.Reporting.Repository.Interfaces
{
    public interface IIctaCubeRepository<T> : IRepository where T : IModel
    {
        public AdomdDataReader GetDatas(string query);
    }
}
