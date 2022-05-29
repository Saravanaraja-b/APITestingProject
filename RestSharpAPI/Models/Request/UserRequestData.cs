using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models.Request
{
    public class UserRequestData
    {     
        
        public string title { get; set; }
        public string body { get; set; }
        public string userId { get; set; }
    }
}
