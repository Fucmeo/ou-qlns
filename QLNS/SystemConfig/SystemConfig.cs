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
            //ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=79184551;Database=QLNS_VPS;"; local
            ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=79184551;Database=QLNS_OU;";
            //ConnectionString = "Server=10.1.12.6;Port=5432;User Id=postgres;Password=qlnsou;Database=QLNS;"; // server ou
            //ConnectionString = "Server=42.112.19.178;Port=5432;Database=QLNS_NEW;User Id=postgres;Password=qlnsou;"; // FTECH
        }
    }
}
