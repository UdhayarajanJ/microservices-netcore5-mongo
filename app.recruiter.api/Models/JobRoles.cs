using app.utility.microservice.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.recruiter.api.Models
{
    public class JobRoles : BaseReponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string documentObjectId { get; set; }
        [BsonElement("roleId")]
        public string id { get; set; }
        [BsonElement("roleName")]
        public string roleName { get; set; }
    }
}
