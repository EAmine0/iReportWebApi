using Icta.Reporting.Data.Interfaces;
using Icta.Reporting.Repository.Interfaces;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

namespace Icta.Reporting.Repository.Implementations
{
    public class IctaCubeRepository<T> : IIctaCubeRepository<T> where T : IModel
    {
        private readonly IIctaCubeConnector<T> _ictaCubeConnector;

        public IctaCubeRepository(IIctaCubeConnector<T> ictaCubeConnector)
        {
            _ictaCubeConnector = ictaCubeConnector;
        }

        public AdomdDataReader GetDatas(string query)
        {
            var data = _ictaCubeConnector.ExecuteQuery(query);

            return data;
        }
    }
}
