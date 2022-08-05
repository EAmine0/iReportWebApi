using Icta.Reporting.Data.Interfaces;
using Icta.Reporting.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Icta.Reporting.Repository.Implementations
{
    public class DataWarehouseRepository<T> : IDataWarehouseRepository<T> where T : IModel
    {
        private readonly IDataWarehouseConnector<T> _dataWarehouseConnector;

        public DataWarehouseRepository(IDataWarehouseConnector<T> dataWarehouseConnector)
        {
            _dataWarehouseConnector = dataWarehouseConnector;
        }

        public SqlDataReader GetDatas(string query)
        {
            var data = _dataWarehouseConnector.ExecuteQuery(query);

            return data;
        }
    }
}
