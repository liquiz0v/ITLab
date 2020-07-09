using System;
using System.Collections.Generic;
using System.Text;


namespace ITLab.Cabinet.Logic.Helpers.Sql
{
    public class ConnectionStringHelper
    {
        static public string GetConnectionString()
        {
            return "Server =.; Database = ITLab_Cabinet; Trusted_Connection = True; MultipleActiveResultSets = true";
        }
    }
}
