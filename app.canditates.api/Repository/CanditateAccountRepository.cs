using app.canditates.api.IRepository;
using app.canditates.api.Models;
using app.utility.microservice.IRepository;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.canditates.api.Repository
{
    public class CanditateAccountRepository : ICanditateAccountRepository
    {
        private IMongoDataContext _mongoDataContext;
        private IDocumentsUploadRepository _documentsUpload;
        private IConfiguration _configuration;
        public CanditateAccountRepository(IMongoDataContext mongoDataContext, IDocumentsUploadRepository documentsUpload, IConfiguration configuration)
        {

            _mongoDataContext = mongoDataContext;
            _documentsUpload = documentsUpload;
            _configuration = configuration;
        }

        public async Task<long> AddCandidateInformation(CandidateAccount candidateAccount)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateAccount> mongoCollection = mongoDatabase.GetCollection<CandidateAccount>("Coll_CandidateInformation");

            candidateAccount.createdDate = DateTime.Now;
            candidateAccount.lastUpdate = DateTime.Now;
            candidateAccount.isDeleted = false;

            await mongoCollection.InsertOneAsync(candidateAccount);
            long result = !string.IsNullOrEmpty(candidateAccount.documentObjectId.ToString()) ? 1 : 0;
            return result;

            throw new NotImplementedException();
        }

        public async Task<long> AddCandidateLoginDetails(CandidateLoginDetails candidateLoginDetails)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateLoginDetails> mongoCollection = mongoDatabase.GetCollection<CandidateLoginDetails>("Coll_CandidateCredential");

            candidateLoginDetails.id = Guid.NewGuid().ToString();
            candidateLoginDetails.createdDate = DateTime.Now;
            candidateLoginDetails.lastUpdate = DateTime.Now;
            candidateLoginDetails.isDeleted = false;

            await mongoCollection.InsertOneAsync(candidateLoginDetails);
            long result = !string.IsNullOrEmpty(candidateLoginDetails.documentObjectId.ToString()) ? 1 : 0;

            return result;
            throw new NotImplementedException();
        }

        public async Task<long> DeleteCandidateLoginDetails(string candidateId)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateLoginDetails> mongoCollection = mongoDatabase.GetCollection<CandidateLoginDetails>("Coll_CandidateCredential");

            var filter = Builders<CandidateLoginDetails>.Filter.Eq(x => x.id, candidateId) & Builders<CandidateLoginDetails>.Filter.Eq(x => x.isDeleted, false);
            var builder = Builders<CandidateLoginDetails>.Update.Set(x => x.isDeleted, true).Set(x => x.lastUpdate, DateTime.Now);

            var resultUpdate = await mongoCollection.UpdateOneAsync(filter, builder);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }

        public Task<DocumentResponse> UploadCandidateFileInformation(IFormFile formFile, string documentSuffixPath)
        {
            FileUploadingModel fileUploadingModel = new FileUploadingModel();
            if (formFile != null)
            {
                string getDocumentFolder = _configuration.GetValue<string>("DocumentsProcessingAPI:DocumentType:" + documentSuffixPath);
                fileUploadingModel.serverURL = string.Concat(_configuration.GetValue<string>("DocumentsProcessingAPI:ServerFileUploadPath:serverBasePath"), getDocumentFolder);
                fileUploadingModel.webURL = string.Concat(_configuration.GetValue<string>("DocumentsProcessingAPI:ServerFileUploadPath:webURLBasePath"), getDocumentFolder, "/");
                fileUploadingModel.file = formFile;
            }
            return _documentsUpload.UploadFileOrImage(fileUploadingModel);
            throw new NotImplementedException();
        }

        public async Task<long> UpdateCandidateInformation(CandidateAccount candidateAccount)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateAccount> mongoCollection = mongoDatabase.GetCollection<CandidateAccount>("Coll_CandidateInformation");

            candidateAccount.lastUpdate = DateTime.Now;
            candidateAccount.isDeleted = false;

            var filter = Builders<CandidateAccount>.Filter.Eq(x => x.id, candidateAccount.id);

            var resultUpdate = await mongoCollection.ReplaceOneAsync(filter, candidateAccount);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }

        public async Task<long> UpdateCandidateLoginDetails(CandidateLoginDetails candidateLoginDetails)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateLoginDetails> mongoCollection = mongoDatabase.GetCollection<CandidateLoginDetails>("Coll_CandidateCredential");

            var filter = Builders<CandidateLoginDetails>.Filter.Eq(x => x.userEmail, candidateLoginDetails.userEmail) & Builders<CandidateLoginDetails>.Filter.Eq(x => x.isDeleted, false);
            var builder = Builders<CandidateLoginDetails>.Update.Set(x => x.lastUpdate, DateTime.Now).Set(x => x.userPassword, candidateLoginDetails.userPassword);

            var resultUpdate = await mongoCollection.UpdateOneAsync(filter, builder);
            long result = resultUpdate.ModifiedCount > 0 ? 1 : 0;
            return result;
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> CheckCandidateLoginDetails(LoginCandidate loginCandidate)
        {
            IMongoDatabase mongoDatabase = await _mongoDataContext.MongoDatabaseConnection();
            IMongoCollection<CandidateLoginDetails> mongoCollection = mongoDatabase.GetCollection<CandidateLoginDetails>("Coll_CandidateCredential");

            LoginResponse userLoginResponse = (from userDetails in mongoCollection.AsQueryable()
                                      where
                                      userDetails.isDeleted == false &&
                                      userDetails.userEmail == loginCandidate.userEmail &&
                                      userDetails.userPassword == loginCandidate.password
                                      select new LoginResponse()
                                      {
                                          userEmailId = userDetails.userEmail,
                                          userId = userDetails.id

                                      }).FirstOrDefault();
            return userLoginResponse;
            throw new NotImplementedException();
        }
    }
}
