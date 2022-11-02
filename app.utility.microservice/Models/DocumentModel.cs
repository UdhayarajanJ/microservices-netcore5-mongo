using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Models
{
    public class DocumentResponse
    {
        public string webURL { get; set; }
        public string serverURL { get; set; }
        public string fileName { get; set; }
    }
    public class FileUploadingModel
    {
        public string webURL { get; set; }
        public string serverURL { get; set; }
        public IFormFile file { get; set; }
    }
}
