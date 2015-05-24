namespace TestLinkedIn.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TestLinkedIn.Data;
    using TestLinkedIn.Web.ViewModels;

    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ITestLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            //var user = this.Data.Users
            //    .All()
            //    .FirstOrDefault(u => u.UserName == username);

            var user = this.Data.Users
                .All()
                .Where(u => u.UserName == username)
                .Select(UserViewModel.ViewModel)
                .FirstOrDefault();
            if (user == null)
            {
                return this.HttpNotFound("User not found");
            }

            //var userViewModel = UserViewModel.FromModel(user);
            return this.View(user);
        }
    }
}