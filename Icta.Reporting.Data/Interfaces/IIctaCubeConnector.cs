using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

namespace Icta.Reporting.Data.Interfaces
{
    public interface IIctaCubeConnector<T> : IDbConnector where T : IModel
    {
        public AdomdDataReader ExecuteQuery(string query);
    }
}
