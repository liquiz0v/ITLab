using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace ITLab.Cabinet.Logic.Helpers.Sql
{
    public interface IConnectionStringHelper
    {
        public string ConnectionString { get; }
    }

    public class ConnectionStringHelper : IConnectionStringHelper
    {
        public string ConnectionString { get; set; }
        public ConnectionStringHelper(IConfiguration connectionString)
        {
            ConnectionString = connectionString["ConnectionStrings:CabinetConnection"];
        }
    }
}
