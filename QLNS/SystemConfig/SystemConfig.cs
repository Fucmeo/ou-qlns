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
            //10.1.14.30
            ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=79184551;Database=QLNS;";
            //ConnectionString = "Server=123.30.210.98;Port=5432;Database=QLNS;User Id=postgres;Password=qlnsou;";
        }
    }
}
