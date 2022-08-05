using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Icta.Reporting.Data.Interfaces
{
    public interface IDataWarehouseConnector<T> : IDbConnector where T : IModel
    {
        public SqlDataReader ExecuteQuery(string query);
    }
}
