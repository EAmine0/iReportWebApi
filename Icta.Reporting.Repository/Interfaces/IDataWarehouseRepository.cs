using Icta.Reporting.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Icta.Reporting.Repository.Interfaces
{
    public interface IDataWarehouseRepository<T> : IRepository where T : IModel
    {
        public SqlDataReader GetDatas(string query);
    }
}
