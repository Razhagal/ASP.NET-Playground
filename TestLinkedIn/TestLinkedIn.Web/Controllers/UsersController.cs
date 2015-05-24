namespace TestLinkedIn.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Data.Entity;

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
            //Include(u => u.Skills)
            //.Include("Skills.Skill")
            //.Include("Skills.Skills.User")

            var user = this.Data.Users
                .All()
                .Include(u => u.Certifications)
                .Include(u => u.Skills)
                .Include("Skills.Skill")
                .Include("Skill.UserSkills.User")
                .Where(u => u.UserName == username)
                .Select(UserViewModel.ViewModel)
                .FirstOrDefault();
            if (user == null)
            {
                return this.HttpNotFound("User not found");
            }

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorceUserForSkill(int id)
        {
            return null;
        }
    }
}