using app.utility.microservice.IRepository;
using app.utility.microservice.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Repository
{
    public class DocumentsUploadRepository : IDocumentsUploadRepository
    {
        public async Task<DocumentResponse> UploadFileOrImage(FileUploadingModel fileUploadingModel)
        {
            string rootPath = rootFolderPath();
            string fileServerPath = string.Concat(rootPath, fileUploadingModel.serverURL);
            bool checkAvailabilityFolderPath = CheckFolderAvailability(fileServerPath);
            DocumentResponse documentResponse=new DocumentResponse();
            if (checkAvailabilityFolderPath)
            {
                string uniqueFileName = GenerateUniqueFileNameAndPath(fileUploadingModel.file);
                fileServerPath = Path.Combine(fileServerPath, uniqueFileName);
                using (FileStream fileStream = new FileStream(fileServerPath, FileMode.Create))
                {
                    await fileUploadingModel.file.CopyToAsync(fileStream);
                }
                documentResponse.fileName = uniqueFileName;
                documentResponse.serverURL = fileServerPath;
                documentResponse.webURL = Path.Combine(fileUploadingModel.webURL, uniqueFileName);
            }
            else
                documentResponse = null;
            return documentResponse;
        }

        private bool CheckFolderAvailability(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return true;
        }

        private string rootFolderPath()
        {
            return Directory.GetCurrentDirectory();
        }

        private string GenerateUniqueFileNameAndPath(IFormFile formFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
            string extentionOfFile = Path.GetExtension(formFile.FileName);
            string setUniqueFileName = string.Concat(fileName, "_", Guid.NewGuid().ToString(), extentionOfFile);
            return setUniqueFileName;
        }
    }
}
