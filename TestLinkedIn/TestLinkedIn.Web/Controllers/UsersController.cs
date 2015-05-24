namespace TestLinkedIn.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Data.Entity;

    using TestLinkedIn.Data;
    using TestLinkedIn.Models;
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
			// TODO: Check if trying to self endorse
            var hasExistingEndorcement = this.Data.Endorcements
                .All()
                .Any(e => e.UserId == this.UserProfile.Id && e.UserSkillId == id);
            if (!hasExistingEndorcement)
            {
                this.Data.Endorcements.Add(new Endorcement
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = id
                });

                this.Data.SaveChanges();
            }

            var endorcements = this.Data.Endorcements
                .All()
                .Where(e => e.UserSkillId == id);
            var endorcementsCount = endorcements.Count();
            var endorcers = endorcements
                .Select(e => e.User.UserName).ToList();

            var joinnedEndorcers = string.Join(", ", endorcers);
            var formattedContent = string.Format("Count: {0} Endorcers: {1}", endorcementsCount, joinnedEndorcers);
            return this.Content(formattedContent);
        }
    }
}