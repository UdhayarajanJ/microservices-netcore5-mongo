using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.utility.microservice.Models
{
    public class CommonApiReponse
    {
        public long statusCode { get; set; }
        public string statusMessage { get; set; }
        public object responseData { get; set; }
    }
    public class MulitpleApiResponse
    { 
        public object responseData1 { get; set; }
        public object responseData2 { get; set; }
        public object responseData3 { get; set; }
    }
}
