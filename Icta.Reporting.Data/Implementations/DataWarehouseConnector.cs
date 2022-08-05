using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Icta.Reporting.Data.Implementations
{
    public class DataWarehouseConnector<T> : IDataWarehouseConnector<T> where T : IModel
    {

        private const string DATA_WAREHOUSE_CONNECTION = "Data Source=ICTAPOWERBI;Initial Catalog=ICTA_DWH;Integrated Security=True";
        private readonly SqlConnection _connection;

        public DataWarehouseConnector()
        {
            _connection = new SqlConnection(DATA_WAREHOUSE_CONNECTION);
            _connection.Open();
        }


        public SqlDataReader ExecuteQuery(string query)
        {
            var cmd = new SqlCommand(query, _connection);
            var reader = cmd.ExecuteReader();

            return reader;

        }

    }
}
