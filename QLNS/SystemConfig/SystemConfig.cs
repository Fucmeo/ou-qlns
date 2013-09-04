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
            //ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=Fucme0.;Database=QLNS_3_SEP;";
            //ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=qlnsou;Database=QLNS;";
            ConnectionString = "Server=42.112.19.178;Port=5432;Database=QLNS_NEW;User Id=postgres;Password=qlnsou;";
            //ConnectionString = "Server=42.112.19.178;Port=5432;Database=QLNS;User Id=postgres;Password=qlnsou;";
        }
    }
}
