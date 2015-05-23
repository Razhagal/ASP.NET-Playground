namespace TestLinkedIn.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using TestLinkedIn.Data;
    using TestLinkedIn.Models;

    public abstract class BaseController : Controller
    {
        private ITestLinkedInData data;
        private User userProfile;

        protected BaseController(ITestLinkedInData data)
        {
            this.Data = data;
        }

        protected BaseController(ITestLinkedInData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ITestLinkedInData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override System.IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All()
                    .FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}