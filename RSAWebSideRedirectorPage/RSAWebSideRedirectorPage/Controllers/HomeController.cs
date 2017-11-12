using RSAWebSideRedirectorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSAWebSideRedirectorPage.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel result = new HomeViewModel();
            result.ConSn = "10820";
            result.Message = "歡迎登入";
            result.PrivateKey = RSAWebSideRedirectorPage.MvcApplication.PrivateKey;
            result.PublicKey = RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPublicKey;
            return View(result);
        }

        [ValidateInput(false)]//防止XSS攻擊先關閉
        public ActionResult LoginValidation(string EnconSn)
        {
             try
            {
                string privateKey = RSAWebSideRedirectorPage.MvcApplication.pulbicKeyList.nowPrivateKey;
                string DeCrytionString = RSAWebSideRedirectorPage.MvcApplication.RsaHelperTool.Decrypt(privateKey, EnconSn);

                if (DeCrytionString == "10820")//解密字串與原字串相同
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch(Exception ex)
            {
                //解密失敗
                return RedirectToAction("Error", "Login");
            }
            //解密字串不對
            return RedirectToAction("Error", "Login");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}