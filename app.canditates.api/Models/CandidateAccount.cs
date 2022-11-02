using app.utility.microservice.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.Models
{
    public class CandidateAccount : BaseReponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string documentObjectId { get; set; }
        [BsonElement("candidateId")]
        public string id { get; set; }
        [BsonElement("candidateName")]
        public string candidateName { get; set; }
        [BsonElement("candidateDescription")]
        public string candidateDescription { get; set; }
        [BsonElement("candidateAddress")]
        public string candidateAddress { get; set; }
        [BsonElement("candidateEmail")]
        public string candidateEmail { get; set; }
        [BsonElement("candidateMobileNumber")]
        public string candidateMobileNumber { get; set; }
        [BsonElement("candidateResumeURL")]
        public string candidateResumeURL { get; set; }
        [BsonElement("candidateProfileURL")]
        public string candidateProfileURL { get; set; }
        [BsonElement("candidateSkills")]
        public List<Skills> candidateSkills { get; set; }
        [BsonElement("candidateEducations")]
        public List<EductationDetails> candidateEducations { get; set; }
        [BsonElement("candidateExperience")]
        public List<ExperienceDetails> candidateExperience { get; set; }

    }
    public class Skills
    {
        [BsonElement("skillName")]
        public string skillName { get; set; }
        [BsonElement("experienceOfSkills")]
        public string experienceOfSkills { get; set; }
    }
    public class EductationDetails
    {
        [BsonElement("collegeName")]
        public string college { get; set; }
        [BsonElement("degree")]
        public string degree { get; set; }
        [BsonElement("startYear")]
        public long startYear { get; set; }
        [BsonElement("endYear")]
        public long endYear { get; set; }
        [BsonElement("currentlyGoingOn")]
        public bool currentlyGoingOn { get; set; }
    }
    public class ExperienceDetails
    {
        [BsonElement("companyName")]
        public string companyName { get; set; }
        [BsonElement("degree")]
        public string roles { get; set; }
        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("startYear")]
        public long startYear { get; set; }
        [BsonElement("endYear")]
        public long endYear { get; set; }
        [BsonElement("currentlyWorkingOn")]
        public bool currentlyWorkingOn { get; set; }
    }
    public class CandidateLoginDetails: BaseReponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string documentObjectId { get; set; }
        [BsonElement("candidateId")]
        public string id { get; set; }
        [BsonElement("userEmail")]
        public string userEmail { get; set; }
        [BsonElement("userPassword")]
        public string userPassword { get; set; }
    }
    public class LoginCandidate
    {
        public string userEmail { get; set; }
        public string password { get; set; }
    }
    public class LoginResponse
    {
        public string userId { get; set; }
        public string userTypeId { get; set; }
        public string userEmailId { get; set; }
    }
}
