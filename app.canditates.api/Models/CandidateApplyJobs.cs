using app.utility.microservice.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.Models
{
    public class CandidateApplyJobs :BaseReponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string documentObjectId { get; set; }
        [BsonElement("jobApplyId")]
        public string id { get; set; }
        [BsonElement("candidateId")]
        public string candidateId { get; set; }
        [BsonElement("jobPostId")]
        public string jobPostId { get; set; }
        [BsonElement("jobApplyDate")]
        public DateTime jobApplyDate { get; set; }
    }

}
