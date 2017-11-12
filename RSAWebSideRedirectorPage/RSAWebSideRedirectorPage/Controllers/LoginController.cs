using RSAWebSideRedirectorPage.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSAWebSideRedirectorPage.Controllers
{
    public class LoginController : Controller
    {
        [ValidateInput(false)]//防止XSS攻擊先關閉
        public ActionResult Index()
        {
            //初始化
            if (RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList == null)
            {
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList = new Models.LoginViewModel();
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPrivateKey = "";
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPublicKey = "";
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.privateKey = new List<string>();
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.publicKey = new List<string>();
                RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.EncryptConsn = new List<string>();
            }
            //每次都產生一組RSA 非對稱密碼
            var getNewRSA = RSAWebSideRedirectorPage.MvcApplication.RsaHelperTool.GenerateRSAKeys();
            //紀錄當前公開金鑰
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPublicKey = getNewRSA.Item1;
            //紀錄當前私有金鑰
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPrivateKey = getNewRSA.Item2;
            //紀錄當前加密後的顧問編號
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowEncryptConsn = RSAWebSideRedirectorPage.MvcApplication.RsaHelperTool.Encrypt(getNewRSA.Item1, "10820");
            //增加公開金鑰
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.publicKey.Add(getNewRSA.Item1);
            //增加私有金鑰
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.privateKey.Add(getNewRSA.Item2);
            //增加加密後的顧問編號
            RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.EncryptConsn.Add(RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowEncryptConsn);



            //傳回Login頁面
            return View(RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList);
        }

        /// <summary>
        /// 導向登入錯誤頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error() {

            return View();
        }
    }
}