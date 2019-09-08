using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetAPI.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Mensagem = "medium.com/@lucas.eschechola"; 
            return View();
        }
    }
}