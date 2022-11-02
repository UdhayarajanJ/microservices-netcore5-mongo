using app.utility.microservice.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace app.recruiter.api.Models
{
    public class JobPost : BaseReponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string documentObjectId { get; set; }
        [BsonElement("jobId")]
        public string id { get; set; }
        [BsonElement("jobTitle")]
        public string jobTitle { get; set; }
        [BsonElement("jobDescription")]
        public string jobDescription { get; set; }
        [BsonElement("salary")]
        public double salary { get; set; }
        [BsonElement("experience")]
        public int experience { get; set; }
        [BsonElement("roleId")]
        public string roleId { get; set; }     
        [BsonIgnore]
        public string roleName { get; set; }
    }
    public class JobPostStatusCount
    {
        public long activeJobs { get; set; }
        public long closedJobs { get; set; }
    }
}
