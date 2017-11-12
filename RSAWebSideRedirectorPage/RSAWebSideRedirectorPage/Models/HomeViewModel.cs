using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSAWebSideRedirectorPage.Models
{
    public class HomeViewModel
    {
        public string Message { get; set;}

        public string ConSn { get; set; }

        public string PublicKey { get; set;}

        public string PrivateKey { get; set; }
    }
}