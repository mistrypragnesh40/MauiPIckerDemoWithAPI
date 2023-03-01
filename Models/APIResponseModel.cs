using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownDemoWithAPI.Models
{
    public class APIResponseModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
    }

    public class TokenResponse
    {
        public string Auth_Token { get; set; }
    }
}
