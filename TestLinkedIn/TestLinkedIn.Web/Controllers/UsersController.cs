namespace TestLinkedIn.Web.Controllers
{
    using System.Web.Mvc;

    using TestLinkedIn.Data;

    public class UsersController : BaseController
    {
        public UsersController(ITestLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            return this.View();
        }
    }
}