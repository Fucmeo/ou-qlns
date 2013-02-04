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
            ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=79184551;Database=QLNS;";
        }
    }
}
