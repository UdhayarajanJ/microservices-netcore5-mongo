using app.utility.microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.IRepository
{
    public interface IDocumentsUploadRepository
    {
        public Task<DocumentResponse> UploadFileOrImage(FileUploadingModel fileUploadingModel);
    }
}
