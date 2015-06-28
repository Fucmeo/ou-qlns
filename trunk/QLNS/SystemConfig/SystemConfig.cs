using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemConfig
{
    public class SystemConfig
    {
        public string ConnectionString { get; private set; }
        public SystemConfig()
        {
            ConnectionString = "Server=qlns.cg7gpptrydzd.ap-southeast-1.rds.amazonaws.com;Port=5432;User Id=postgres;Password=postgresqlnsou;Database=QLNS_OU;";

            //ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=79184551;Database=QLNS_VPS;"; //local

            //ConnectionString = "Server=10.1.12.6;Port=5432;User Id=postgres;Password=qlnsou;Database=QLNS;"; // server ou
        }
    }
}
