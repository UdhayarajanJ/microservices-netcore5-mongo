using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Models
{
    public class MongoDatabaseConfiguration
    {
        public string mongoDatabaseLocalConnectionString { get; set; }
        public string mongoDatabaseServerConnectionString { get; set; }
        public string mongoDatabase { get; set; }
        public bool isConnectServerDatabase { get; set; }
    }
}
