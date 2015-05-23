namespace TestLinkedIn.Data
{
    using TestLinkedIn.Data.Repositories;
    using TestLinkedIn.Models;

    public interface ITestLinkedInData
    {
        IRepository<User> Users { get; }

        IRepository<Certification> Certifications { get; }

        IRepository<Discussion> Discussions { get; }

        IRepository<Experience> Experiences { get; }

        IRepository<Group> Groups { get; }

        IRepository<Project> Projects { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Endorcement> Endorcements { get; }

        IRepository<AdministrationLog> AdministrationLogs { get; }

        int SaveChanges();
    }
}
