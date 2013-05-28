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
            ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=qlnsou;Database=QLNS;";
            //ConnectionString = "Server=123.30.210.98;Port=5432;Database=QLNS;User Id=postgres;Password=qlnsou;";
            //ConnectionString = "Server=10.1.12.6;Port=5432;Database=QLNS;User Id=postgres;Password=qlnsou;";
        }
    }
}
