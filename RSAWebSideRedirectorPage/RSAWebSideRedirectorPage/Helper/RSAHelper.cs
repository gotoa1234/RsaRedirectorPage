using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RSAWebSideRedirectorPage.Helper
{
    /// <summary>
    /// 參考的點部落 : https://dotblogs.com.tw/supershowwei/2015/12/23/160510
    /// QUeryString最大長度 : https://dotblogs.com.tw/jimmyyu/2010/03/25/asp-net-40-max-query-string-length
    /// </summary>
    public class RSAHelper
    {
        /// <summary>
        /// 產生公開金鑰 與 私有金鑰
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> GenerateRSAKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);

            return Tuple.Create<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publicKey">公開金鑰</param>
        /// <param name="content">加密文本</param>
        /// <returns></returns>
        public string Encrypt(string publicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var encryptString = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(content), false));

            return encryptString;
        }
        /// <summary>
        /// 解密RSA
        /// </summary>
        /// <param name="privateKey">放進私有金鑰</param>
        /// <param name="encryptedContent">已經加密的文本，欲進行解密的資料</param>
        /// <returns></returns>
        public string Decrypt(string privateKey, string encryptedContent)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var decryptString = Encoding.UTF8.GetString(rsa.Decrypt(Convert.FromBase64String(encryptedContent), false));

            return decryptString;
        }

    }
}