namespace TestLinkedIn.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using TestLinkedIn.Data;

    public class HomeController : BaseController
    {
        public HomeController(ITestLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.RedirectToAction(x => x.Contact());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}