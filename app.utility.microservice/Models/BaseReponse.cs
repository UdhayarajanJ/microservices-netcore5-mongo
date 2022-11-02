using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Models
{
    public class BaseReponse
    {
        [BsonElement("isDeleted")]
        public bool isDeleted { get; set; }
        [BsonElement("createdDate")]
        public DateTime createdDate { get; set; }
        [BsonElement("lastUpdate")]
        public DateTime lastUpdate { get; set; }
    }
}
