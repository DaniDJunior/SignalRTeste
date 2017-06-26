using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRTeste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubs.TesteHub>();
            //hubContext.Clients.All.MessageReciever("teste");
            return View();
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

        [HttpPost]
        public ActionResult UpdateAll(string txtMessage)//, int? PacSize)
        {
            Hubs.DisparaHub.dispara(txtMessage);
            return RedirectToAction("Index", "Home");
        }
    }
}