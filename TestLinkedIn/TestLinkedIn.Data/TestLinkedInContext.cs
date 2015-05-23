namespace TestLinkedIn.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using TestLinkedIn.Models;

    public class TestLinkedInContext : IdentityDbContext<User>
    {
        public TestLinkedInContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TestLinkedInContext Create()
        {
            return new TestLinkedInContext();
        }
    }
}
