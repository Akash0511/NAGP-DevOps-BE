using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NagpDevOpsApp.Config
{
    public class ServerConfig
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
    }
}
