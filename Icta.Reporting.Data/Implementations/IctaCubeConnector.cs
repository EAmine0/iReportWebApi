using Icta.Reporting.Data.Interfaces;
using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;

namespace Icta.Reporting.Data.Implementations
{
    public class IctaCubeConnector<T> : IIctaCubeConnector<T> where T : IModel
    {
        private const string cubeSource = @"Provider=SQLNCLI11.1;Data Source=report.icta.fr;Initial Catalog=ICTA_CUBE;Integrated Security=SSPI";
        private readonly AdomdConnection _connection;

        public IctaCubeConnector()
        {
            _connection = new AdomdConnection(cubeSource);
            _connection.Open();
        }


        public AdomdDataReader ExecuteQuery(string query)
        {
            var command = new AdomdCommand(query, _connection);
            var reader = command.ExecuteReader();
            //var readeread = reader.Read();

            return reader;

        }
    }
}
