using System;
using System.Collections.Generic;
using System.Text;

namespace Library.SqlDal
{
    public class SqlDalConfig
    {
        public SqlDalConfig(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
