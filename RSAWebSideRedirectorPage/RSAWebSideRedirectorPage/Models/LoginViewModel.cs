using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSAWebSideRedirectorPage.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 公開金鑰清單
        /// </summary>
        public List<string> publicKey { get; set; }

        /// <summary>
        /// 私有金鑰清單
        /// </summary>
        public List<string> privateKey { get; set; }

        /// <summary>
        /// 加密後的密文資料清單
        /// </summary>
        public List<string> EncryptConsn { get; set; }

        /// <summary>
        /// 現存的公開金鑰
        /// </summary>
        public string nowPublicKey { get; set;}
        
        /// <summary>
        /// 現存的私有金鑰
        /// </summary>
        public string nowPrivateKey { get; set;}

        /// <summary>
        /// 現在加密後的顧問序號
        /// </summary>
        public string nowEncryptConsn { get; set;}
    }
}